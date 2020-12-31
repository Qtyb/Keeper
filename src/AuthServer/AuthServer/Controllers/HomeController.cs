using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Hosting;

namespace AuthServer.Controllers
{
    [SecurityHeaders]
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}
    }
}
