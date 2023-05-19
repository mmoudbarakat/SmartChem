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
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            //var apiClient = new ApiClient(new HttpClient());
            
            //var response = await apiClient.GetAsync<T>("https://localhost:7173/api/SmartChem");
            //List<Element> elements = JsonConvert.DeserializeObject<List<Element>>(response);
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

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        public class Element
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int AtomicNumber { get; set; }
            public string AtomicMass { get; set; }
            public string ElementName { get; set; }
            public string Valence { get; set; }
        }




        //public class ApiClient
        //{




        //    private readonly HttpClient _httpClient;

        //    public ApiClient(HttpClient httpClient)
        //    {
        //        _httpClient = httpClient;
        //    }

        //    public async Task<TResponse> GetAsync<TResponse>(string endpoint)
        //    {
        //        var response = await _httpClient.GetAsync(endpoint);
        //        var content = await response.Content.ReadAsStringAsync();

        //        if (!response.IsSuccessStatusCode)
        //        {
        //            throw new Exception($"Failed to retrieve data from API. Status code: {response.StatusCode}. Response: {content}");
        //        }

        //        return JsonConvert.DeserializeObject<TResponse>(content);
        //    }
        //}
    
    }


    // Do something with the response


}