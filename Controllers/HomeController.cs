using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SistemaNH.Models; //OJO HP AGREGA ESPACIO DE NOMBRES
using SistemaNH.Models.ViewModel; //OJO HP AGREGA ESPACIO DE NOMBRES
using SistemaNH.Models.DAO; //OJO HP AGREGA ESPACIO DE NOMBRES

namespace SistemaNH.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost] //OJO HP
        [ValidateAntiForgeryToken] //OJO HP
         public IActionResult Login(Login login)
        {
            Conexion.GetInstance().GetConnection();   
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
