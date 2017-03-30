using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace coreMvcTest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //These are the header keys that we would be interested in. 
            // 1) SM_USER and USER_UID both return the login name, guimondmi for me or strongsr for you.
            // 2) NIH_EMPLOYEEID will return the NED ID of the authenticated person.
            // 3) you can also use USER_DN to display the users "Display name" i.e. Strong, Stephen (NIH\OD) [C]
            string strHeaderKey =  HttpContext.Request.Headers["User-Agent"].ToString();

            HttpContext.Session.SetString("headerString", strHeaderKey);

            return View();
        }

        public IActionResult About()
        {
            string strSessionValue =  HttpContext.Session.GetString("headerString");

            ViewBag.Message = String.Format("User-Agent: {0}", strSessionValue);

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
