using System.ComponentModel.DataAnnotations;

namespace EF_Core1.Models;

public class Category
{
    public byte Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
}
