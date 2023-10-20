using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace project_ef.Models;

public class Category
{
    //[Key]
    public Guid Id { get; set; }
    //[Required]
    //[MaxLength(250)]
	public string Name { get; set; }
    public string Description { get; set; }
    public int Weight { get; set; }

    [JsonIgnore]
    public virtual ICollection<Task> Tasks { get; set; }

    public Category()
	{
	}
}

public static class CategoryFluent
{
    public static Category Id(this Category category,string guid)
    {
        category.Id = Guid.Parse(guid);
        return category;
    }

    public static Category Name(this Category category, string name)
    {
        category.Name = name;
        return category;
    }

    public static Category Description(this Category category, string description)
    {
        category.Description = description;
        return category;
    }

    public static Category Weight(this Category category, int weight)
    {
        category.Weight = weight;
        return category;
    }
}