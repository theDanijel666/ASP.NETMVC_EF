using Microsoft.AspNetCore.Mvc;
using MVC_Spajanje_DB.Models;
using System.Diagnostics;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration.Json;

namespace MVC_Spajanje_DB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        private string _connectionString = "Data Source=.\\sqlexpress2019;Initial catalog=Fakultet;Integrated security=true;TrustServerCertificate=true";
        public IActionResult Index()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    ViewBag.Message = "Veza na bazu podataka uspostavljena :)";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Došlo je do pogreške: " + ex.Message;
            }
            return View();
        }

        public IActionResult Citajappsettings()
        {
            try
            {
                var configuration = new ConfigurationBuilder().SetBasePath(
                    AppDomain.CurrentDomain.BaseDirectory.Split(
                        new String[] { @"bin\" }, StringSplitOptions.None)[0]).AddJsonFile("appsettings.json").Build();
                string constr = configuration.GetConnectionString("Baza");
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    ViewBag.Message = "Veza na bazu podataka uspostavljena :)";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Došlo je do pogreške: " + ex.Message;
            }
            return View("Index");
        }

        public IActionResult SpojiSe()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Baza")))
                {
                    con.Open();
                    ViewBag.Message = "Veza na bazu podataka uspostavljena :)";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Došlo je do pogreške: " + ex.Message;
            }
            return View("Index");
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
