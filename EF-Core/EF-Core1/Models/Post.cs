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
    public List<PostTag> PostTags { get; set; }
    // public int BlogId { get; set; }
    // public Blog Blog { get; set; }
}

public class Tag
{
    public int Id { get; set; }
    public ICollection<Post> Posts { get; set; }
    public List<PostTag> PostTags { get; set; }
}

public class PostTag
{
    public int PostId { get; set; }
    public Post Post { get; set; }
    public int TagId { get; set; }
    public Tag Tag { get; set; }
    public DateTime AddedOne { get; set; }
}
