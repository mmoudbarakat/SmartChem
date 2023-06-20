using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SmartChemMVC.Models;
using System.Diagnostics;
using System.Net.Http;


namespace SmartChemMVC.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly HttpClient httpClient;


        public HomeController(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        //[Authorize]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            
            return View();
        }

        public IActionResult ConstantsList()
        {

            return View();
        }



        public IActionResult Tools()
        {
            return View();
        }


        public class Element
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int AtomicNumber { get; set; }
            public string AtomicMass { get; set; }
            public string ElementName { get; set; }
            public string Valence { get; set; }
        }

    
    }





}