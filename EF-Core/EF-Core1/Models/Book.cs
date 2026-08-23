using System.ComponentModel.DataAnnotations;

namespace EF_Core1.Models;

public class Book
{
    // [Key] This sets the BookKey to be PK
    public int BookKey { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
}
