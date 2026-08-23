using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Core1.Models;

public class Blog
{
    public int Id { get; set; }

    // [Required]
    public string Url { get; set; }

    // [NotMapped] → Data annotaiton way to Exclude Entity from model
    public List<Post> Posts { get; set; }

    // [NotMapped]  Data annotaiton way to Exclude property from model
    public DateTime AddedOn { get; set; }
}
