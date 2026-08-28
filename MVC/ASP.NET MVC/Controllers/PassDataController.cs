using ASP.NET_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_MVC.Controllers
{
    public class PassDataController : Controller
    {
        public ProjectContext ProjectContext = new ProjectContext();

        public IActionResult TestViewData(int id)
        {
            Employee empModel = ProjectContext.Employees.FirstOrDefault(e => e.Id == id);
            // Extra info to send
            string msg = "Hello";
            List<string> branchs = new List<string>();
            branchs.Add("Alex");
            branchs.Add("Smart");
            branchs.Add("Sohag");
            branchs.Add("Assuit");
            branchs.Add("Minia");
            int temp = 44;
            string color = "Red";

            ViewData["Message"] = msg;
            ViewData["brch"] = branchs;
            ViewData["Temp"] = temp;
            ViewData["Color"] = color;

            return View(empModel);
        }
    }
}