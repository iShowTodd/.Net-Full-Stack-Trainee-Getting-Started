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
                //message = TempData["msg"].ToString(); // Normal Read
                message = TempData.Peek("msg").ToString(); // Means in term of cookies "Give it another Chance"
            }
            return Content("get1" + message);
        }

        public IActionResult GetTwo()
        {
            string? message = TempData["msg"].ToString(); // normal read
            TempData.Keep("msg"); // After the request do not delete this key
            return Content("get2" + message);
        }
    }
}