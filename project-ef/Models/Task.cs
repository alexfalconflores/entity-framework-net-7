using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_ef.Models;

public class Task
{
	//[Key]
	public Guid Id { get; set; }
	//[ForeignKey("CategoryId")]
	public Guid CategoryId { get; set; }
	//[Required]
	//[MaxLength(250)]
	public string Title { get; set; }
	public string Description { get; set; }
	public Priority TaskPriority { get; set; }
    public DateTime CreationDate { get; set; }
    public virtual Category Category { get; set; }
	//[NotMapped]
	public string Summary { get; set; }

	public Task()
	{
	}
}

public enum Priority
{
	low,
	Medium,
	High
}

public static class TaskFluent
{
    public static Task Id(this Task task, string guid)
    {
        task.Id = Guid.Parse(guid);
        return task;
    }

    public static Task CategoryId(this Task task, string guid)
    {
        task.CategoryId = Guid.Parse(guid);
        return task;
    }

    public static Task Title(this Task task, string title)
    {
        task.Title = title;
        return task;
    }

    public static Task Description(this Task task, string description)
    {
        task.Description = description;
        return task;
    }

    public static Task TaskPriority(this Task task, Priority taskPriority)
    {
        task.TaskPriority = taskPriority;
        return task;
    }

    public static Task CreationDate(this Task task, DateTime creationDate)
    {
        task.CreationDate = creationDate;
        return task;
    }

    //public static Task CreationDate(this Task task, DateTimeOffset creationDate)
    //{
    //    task.CreationDate = DateTimeOffset.Now;
    //}
}

