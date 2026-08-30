using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_MVC.Controllers
{
    public class StateManagementController : Controller
    {
        public IActionResult SetCookie()
        {
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTimeOffset.Now.AddHours(1);
            Response.Cookies.Append("Name", "Ahmed");
            Response.Cookies.Append("Age", "21");
            return Content("Cookie Saved");
        }

        public IActionResult GetCookie()
        {
            string name = Request.Cookies["Name"];
            int age = int.Parse(Request.Cookies["Age"]);
            return Content($" {name} {age}");
        }

        public IActionResult SetSession()
        {
            HttpContext.Session.SetString("NAME", "Ahmed");
            HttpContext.Session.SetInt32("AGE", 21);
            return Content("Session Data Saved");
        }

        public IActionResult GetSessionData()
        {
            string name = HttpContext.Session.GetString("NAME");
            int? age = HttpContext.Session.GetInt32("AGE");
            return Content($"{name} {age}");
        }

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