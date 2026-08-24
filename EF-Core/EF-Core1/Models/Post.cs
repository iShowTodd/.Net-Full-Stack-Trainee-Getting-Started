using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Core1.Models;

// [Table("Posts")]
//[Table("Posts) , schema = "blogging" ]
public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public ICollection<Tag> Tags { get; set; }
    // public int BlogId { get; set; }
    // public Blog Blog { get; set; }
}

public class Tag
{
    public int Id { get; set; }
    public ICollection<Post> Posts { get; set; }
}
