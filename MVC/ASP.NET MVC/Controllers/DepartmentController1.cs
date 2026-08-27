using ASP.NET_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_MVC.Controllers
{
    public class DepartmentController1 : Controller
    {
        private ProjectContext _db = new ProjectContext();

        public IActionResult Index()
        {
            var depts = _db.Departments.ToList();
            return View("Index", depts);
        }
    }
}