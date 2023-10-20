using Microsoft.EntityFrameworkCore;
using project_ef.Models;

namespace project_ef;

public class TasksContext : DbContext
{
	public DbSet<Category> Categories { get; set; }
	public DbSet<Models.Task> Tasks { get; set; }

	public TasksContext(DbContextOptions<TasksContext> options): base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		List<Category> CategoryInit = new()
		{
			new Category().Id("f41c1bb2-b8ff-447e-a1df-0bf091f26d1c").Name("Actividades Pendientes").Weight(20),
			new Category().Id("311fcc30-77c4-4ea0-9d03-685266df766f").Name("Actividades Personales").Weight(50),
		};

		modelBuilder.Entity<Category>(category =>
		{
			category.ToTable("Category");
			category.HasKey(p => p.Id);
			category.Property(p => p.Name).IsRequired().HasMaxLength(250);
			category.Property(p => p.Description).IsRequired(false);
			category.Property(p => p.Weight);

			category.HasData(CategoryInit);
		});

		List<Models.Task> TasksInit = new()
		{
			new Models.Task()
				.Id("d80f1fd0-d62a-49db-8da2-79ff95c712c7").CategoryId("f41c1bb2-b8ff-447e-a1df-0bf091f26d1c")
				.TaskPriority(Priority.Medium).Title("Pago de servicios publicos"),
            new Models.Task()
                .Id("8b9f19f8-7900-4e05-ac39-e53e4c8630d6").CategoryId("311fcc30-77c4-4ea0-9d03-685266df766f")
                .TaskPriority(Priority.low).Title("Terminar de ver pelicula")
        };

		modelBuilder.Entity<Models.Task>(task =>
		{
			task.ToTable("Task");
			task.HasKey(p => p.Id);
			task.HasOne(p => p.Category).WithMany(p => p.Tasks).HasForeignKey(p => p.CategoryId);
			task.Property(p => p.Title).IsRequired().HasMaxLength(250);
			task.Property(p => p.Description).IsRequired(false);
			task.Property(p => p.TaskPriority);
			task.Property(p => p.CreationDate).HasDefaultValue(DateTime.Now);
			task.Ignore(p => p.Summary);

			task.HasData(TasksInit);
		});
	}
}

