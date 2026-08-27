using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET_MVC.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string? Image { get; set; }
        public string Address { get; set; }

        [ForeignKey("Department")]
        public int DeptId { get; set; }

        public virtual Department? Department { get; set; }
    }
}