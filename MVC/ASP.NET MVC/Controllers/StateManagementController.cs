using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_MVC.Controllers
{
    public class StateManagementController : Controller
    {
        public IActionResult SetTempData()
        {
            TempData["msg"] = "Hello"; // Just One Request then it get destroied
            return Content("DataSaved");
        }

        public IActionResult GetOne()
        {
            string message = "Empty Message";
            if (TempData.ContainsKey("msg"))
            {
                message = TempData["msg"].ToString();
            }
            return Content("get1" + message);
        }

        public IActionResult GetTwo()
        {
            string? message = TempData["msg"].ToString();
            return Content("get2" + message);
        }
    }
}