using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SmartChemMVC.Models;
using System.Data;
using System.Linq;
using System.Net.Http;


namespace SmartChemMVC.Controllers
{
    public class ElementController : Controller
    {
        
        
        //public  IActionResult Index()
        //{
            

        //        return View();
        //}


        private readonly HttpClient httpClient;

        public ElementController(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        //List of Element
        public async Task<List<Element>> GetElementsAsync()
        {
            // Make HTTP GET request to API endpoint
            HttpResponseMessage response = await httpClient.GetAsync("https://localhost:7173/api/SmartChem");

            // Throw exception if response is not successful
            response.EnsureSuccessStatusCode();

            // Read response content as string
            string responseContent = await response.Content.ReadAsStringAsync();

            // Deserialize JSON data into list of Element objects
            List<Element> elements = JsonConvert.DeserializeObject<List<Element>>(responseContent);

            return elements;




        }
        //return one element
        public async Task<IActionResult> GetElementAsync(int id)
        {
            // Make HTTP GET request to API endpoint
            
            HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7173/api/SmartChem/{id}");

            // Throw exception if response is not successful
            response.EnsureSuccessStatusCode();

            // Read response content as string
            string responseContent = await response.Content.ReadAsStringAsync();

            // Deserialize JSON data into an Element object
            Element element1 = JsonConvert.DeserializeObject<Element>(responseContent);
            //Element2 element2 = JsonConvert.DeserializeObject<Element2>(responseContent);
            //MyViewModel viewModel = JsonConvert.DeserializeObject<MyViewModel>(responseContent);


            return View(element1);
        }

        public async Task<IActionResult> IndexAsync(int id1, int id2)
        {
            HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7173/api/SmartChem/{id1}");
            string responseContent = await response.Content.ReadAsStringAsync();
            Element element1 = JsonConvert.DeserializeObject<Element>(responseContent);
            HttpResponseMessage response2 = await httpClient.GetAsync($"https://localhost:7173/api/SmartChem/{id2}");
            string responseContent2 = await response2.Content.ReadAsStringAsync();
            Element element2 = JsonConvert.DeserializeObject<Element>(responseContent2);
            var firstElement = new Element
            {
                Id = element1.Id,
                Name = element1.Name,
                AtomicNumber = element1.AtomicNumber,
                AtomicMass = element1.AtomicMass,
                ElementName = element1.ElementName,
                Valence = element1.Valence

            };

            var secondElement = new Element
            {
                Id = element2.Id,
                Name = element2.Name,
                AtomicNumber = element2.AtomicNumber,
                AtomicMass = element2.AtomicMass,
                ElementName = element2.ElementName,
                Valence = element2.Valence
            };

            var viewModel = new ElementViewModel
            {
                FirstElement = firstElement,
                SecondElement = secondElement
            };

            return View(viewModel);
        }







    }







}
