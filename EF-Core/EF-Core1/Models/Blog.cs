using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EF_Core1.Models;

// [Index(nameof(Url))]
public class Blog
{
    public int Id { get; set; }

    [Required]
    // [Column("BlogURL")]
    // [Column(TypeName = "varchar(200)")]
    [MaxLength(200)]
    // [Comment("this comment is about URL")]
    public string Url { get; set; }

    // public BlogImage BlogImage { get; set; }
    // public int Rating { get; set; }

    // [NotMapped] → Data annotaiton way to Exclude Entity from model
    // public List<Post> Posts { get; set; }

    // [NotMapped]  Data annotaiton way to Exclude property from model
    // public DateTime AddedOn { get; set; }
}
