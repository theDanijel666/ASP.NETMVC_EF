using Microsoft.AspNetCore.Mvc;
using MVC_spajanje_repo.Models;
using MVC_spajanje_repo.Repository;
using System.Diagnostics;

namespace MVC_spajanje_repo.Controllers
{
    public class HomeController : Controller
    {
        private HomeRepo _repo;

        public HomeController(IConfiguration configuration)
        {
            _repo= new HomeRepo(configuration);
        }

        public IActionResult Index()
        {
            bool check=_repo.CheckConnection();
            if (check) ViewBag.Message = "Veza na bazu uspješna";
            else ViewBag.Message = "Veza na bazu nije uspostavljena!";
            return View();
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
