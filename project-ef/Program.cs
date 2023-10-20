using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_ef;
using project_ef.Models;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TasksContext>(p => p.UseInMemoryDatabase("TareasDB"));
builder.Services.AddNpgsql<TasksContext>(builder.Configuration.GetConnectionString("TasksDB")); // PostSQL
//builder.Services.AddSqlServer<TasksContext>(builder...); //SQL Server

var app = builder.Build();

app.MapGet("/", () => "Hello World");
app.MapGet("/dbconexion", ([FromServices] TasksContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok($"DataBase on memory {dbContext.Database.IsInMemory()}");
});

app.MapGet("/api/taks", ([FromServices] TasksContext dbContext) =>
{
    return Results.Ok(dbContext.Tasks.Include(p => p.Category));
});

app.MapGet("/api/taks/low", ([FromServices] TasksContext dbContext) =>
{
    return Results.Ok(dbContext.Tasks.Where(p => p.TaskPriority == Priority.low));
});

app.MapGet("/api/taks/with-category", ([FromServices] TasksContext dbContext) =>
{
    return Results.Ok(dbContext.Tasks.Include(p => p.Category).Where(p => p.TaskPriority == Priority.low));
});

app.MapPost("/api/taks", async ([FromServices] TasksContext dbContext, [FromBody] project_ef.Models.Task task) =>
{
    task.Id = Guid.NewGuid();
    task.CreationDate = DateTime.Now;
    await dbContext.AddAsync(task);
    await dbContext.SaveChangesAsync();
    return Results.Ok();
});

app.MapPut("/api/taks/{id}", async ([FromServices] TasksContext dbContext, [FromBody] project_ef.Models.Task task, [FromRoute] Guid id) =>
{
    var currentTask = dbContext.Tasks.Find(id);
    if(currentTask is not null)
    {
        currentTask.CategoryId = task.CategoryId;
        currentTask.Title = task.Title;
        currentTask.TaskPriority = task.TaskPriority;
        currentTask.Description = task.Description;
        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }
    return Results.NotFound();
});

app.MapDelete("/api/taks/{id}", async ([FromServices] TasksContext dbContext, [FromRoute] Guid id) =>
{
    var currentTask = dbContext.Tasks.Find(id);
    if (currentTask is not null)
    {
        dbContext.Remove(currentTask);
        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }
    return Results.NotFound();
});

app.Run();

