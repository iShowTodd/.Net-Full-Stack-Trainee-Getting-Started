using Microsoft.EntityFrameworkCore;

namespace EF_Core1;

// [Index(nameof(FirstName), nameof(LastName), IsUnique = true, Name = "Index_url")]
public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
