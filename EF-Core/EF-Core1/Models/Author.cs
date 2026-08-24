using System.ComponentModel.DataAnnotations;

namespace EF_Core1.Models;

public class Author
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }

    [MaxLength(50)]
    public string DisplayName { get; set; }
}
