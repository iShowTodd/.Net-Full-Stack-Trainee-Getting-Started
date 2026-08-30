using ASP.NET_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_MVC.Controllers
{
    public class PassDataController : Controller
    {
        public ProjectContext ProjectContext = new ProjectContext();

        public IActionResult TestViewData(int id)
        {
            Employee? empModel = ProjectContext.Employees.FirstOrDefault(e => e.Id == id);

            if (empModel == null)
                return NotFound();

            ViewData["Message"] = "Hello";
            ViewData["brch"] = new List<string> { "Alex", "Smart", "Sohag", "Assuit", "Minia" };
            ViewData["Temp"] = 44;
            ViewData["Color"] = "Red";

            return View(empModel);
        }
    }
}