using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Core1.Models;

public class BlogImage
{
    public int Id { get; set; }
    public string Image { get; set; }

    [Required, MaxLength(250)]
    public string Caption { get; set; }
    public int BlogForeignKey { get; set; } // This is a FK

    // [ForeignKey("BlogForeignKey")]
    public Blog Blog { get; set; }
}
