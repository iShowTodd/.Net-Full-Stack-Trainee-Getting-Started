using ASP.NET_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_MVC.Controllers
{
    public class DepartmentController : Controller
    {
        private ProjectContext _db = new ProjectContext();

        public IActionResult Index()
        {
            var depts = _db.Departments.Include(e => e.Employees).ToList();
            //return View("Index", depts);  // View = Index , Model = depts
            return View(depts); // View = Index , Model = depts
            //return View(); // View = Index , Model = null
            //return View("Index"); // View = Index , Model = null
        }
    }
}