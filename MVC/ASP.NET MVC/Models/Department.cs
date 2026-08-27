using System.ComponentModel.DataAnnotations;

namespace ASP.NET_MVC.Models
{
    public class Department
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string ManagerName { get; set; }
    }
}