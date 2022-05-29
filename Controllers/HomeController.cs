using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace moneylandingApp.Controllers
{
    public class HomeController: Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Contact()
        {
            return View();
        }


        public IActionResult About()
        {
            return View();
        }


    }
}
