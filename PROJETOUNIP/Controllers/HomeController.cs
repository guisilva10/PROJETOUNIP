using Microsoft.AspNetCore.Mvc;
using PROJETOUNIP.Models;
using System.Diagnostics;

namespace PROJETOUNIP.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
           HomeModel home = new HomeModel();

            home.Nome = "Augusto";
            home.Email = "augusto@gmail.com";

            return View(home);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
