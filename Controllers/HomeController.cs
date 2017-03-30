using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace coreMvcTest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            var headers = String.Empty;
            foreach (var key in HttpContext.Request.Headers.Keys)
                ViewBag.Message = headers += key + "=" + HttpContext.Request.Headers[key] + Environment.NewLine;

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
