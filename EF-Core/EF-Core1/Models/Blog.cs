using System.ComponentModel.DataAnnotations;

namespace EF_Core1.Models;

public class Blog
{
    public int Id { get; set; }

    // [Required]
    public string Url { get; set; }
    public List<Post> Posts { get; set; }
}
