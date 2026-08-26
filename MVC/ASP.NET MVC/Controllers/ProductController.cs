using ASP.NET_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_MVC.Controllers;

public class ProductController : Controller
{
    public IActionResult Details(int id)
    {
        // Model
        ProductSampleData productSampleData = new ProductSampleData();
        Product productModel = productSampleData.GetById(id);
        return View("ProductDetails", productModel);
    }

    // GET
    // this is called Action (NOT METHOD) , this is can not either be private or static or overloaded
    // public IActionResult Index()
    // {
    //     return View();
    // }

    public string showMsg()
    {
        return "Hello from MVC";
    }

    public ContentResult showMsg2()
    {
        // Declare Object
        var contentResult = new ContentResult();
        // Set Data
        contentResult.Content = "This is my content result message";
        // Return it
        return contentResult;
    }

    public ViewResult showView()
    {
        var viewResult = new ViewResult();
        viewResult.ViewName = "View1";
        return viewResult;
    }

    public JsonResult showJson()
    {
        var jsonResult = new JsonResult(new { Id = 1, Name = "Ahmed" });
        return jsonResult;
    }

    // Path Param or Query Param
    public IActionResult ShowResult(int id)
    {
        if (id % 2 == 0)
        {
            // Declare Object
            var contentResult = new ContentResult();
            // Set Data
            contentResult.Content = "Local Message";
            // Return it
            return contentResult;
        }
        var viewResult = new ViewResult();
        viewResult.ViewName = "View1";
        return viewResult;
    }

    // for Json → return Json({});

    public IActionResult ShowMix(int id)
    {
        if (id % 2 == 0)
        {
            return Content("This is a new way of sending");
        }
        return View("View1");
    }

    // Types the Action can return
    // 1. Views (HTML files) ==> ViewResult
    // 2. Content or Data types ==> ContentResult
    // 3. Actually can return nothing ("No Content") ==> NotFoundReult
    // 4. JavaScript and JSON ==> JavascriptResult / JsonResult
    // 5. Files
}