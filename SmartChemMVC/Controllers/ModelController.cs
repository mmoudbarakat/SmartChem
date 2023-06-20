using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SmartChemMVC.Models;

namespace SmartChemMVC.Controllers
{
    public class ModelController : Controller
    {
        //Index View
        public IActionResult Index()
        {
            return View();
        }



        //Compound View
        public async Task<IActionResult> GetCompoundData(string compoundName)
        {
            if (string.IsNullOrEmpty(compoundName))
            {
                
                return View();
            }

            // Create an instance of HttpClient
            using (HttpClient client = new HttpClient())
            {
                // Construct the API URL using the compoundName parameter
                string apiUrl = $"https://chemgeek.live/compounds/{compoundName}";

                // Make the GET request to the API
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as string
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON response
                    var compoundData = JsonConvert.DeserializeObject<CompoundData>(jsonResponse);

                    
                    return View(compoundData);
                }
                else
                { 
                    return View("Error");
                }
            }


        }




        public IActionResult PostReactions()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SubmitReactions(string precursors)
        {
            using (HttpClient client = new HttpClient())
            {
                var requestBody = new { precursors };
                var jsonContent = JsonConvert.SerializeObject(requestBody);
                var request = new HttpRequestMessage(HttpMethod.Post, "https://chemgeek.live/reactions")
                {
                    Content = new StringContent(jsonContent, Encoding.UTF8, "application/json")
                };

                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var reactionsResult = JsonConvert.DeserializeObject<ReactionsResultViewModel>(jsonResponse);
                    return View("PostReactions", reactionsResult);
                }
                else
                {
                    return View("Error");
                }
            }
        }





        ///////////////////////
        public IActionResult DrawMolecule()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubmitDrawRequest(string mf)
        {
            using (HttpClient client = new HttpClient())
            {
                var requestBody = new { mf };
                var jsonContent = JsonConvert.SerializeObject(requestBody);
                var request = new HttpRequestMessage(HttpMethod.Post, "https://chemgeek.live/draw")
                {
                    Content = new StringContent(jsonContent, Encoding.UTF8, "application/json")
                };

                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    byte[] imageBytes = await response.Content.ReadAsByteArrayAsync();
                    string base64Image = Convert.ToBase64String(imageBytes);
                    var imageResult = new ImageResultViewModel { ImageUrl = $"data:image/png;base64,{base64Image}" };
                    return View("DrawMolecule", imageResult);
                }
                else
                {
                    return View("Error");
                }
            }
        }



        /////////////////////////////
        public IActionResult PostRetrosyntheses()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubmitRetrosyntheses(RetrosynthesisRequest model)
        {
            using (HttpClient client = new HttpClient())
            {
                var jsonContent = JsonConvert.SerializeObject(model);
                var request = new HttpRequestMessage(HttpMethod.Post, "https://chemgeek.live/retrosyntheses")
                {
                    Content = new StringContent(jsonContent, Encoding.UTF8, "application/json")
                };

                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var retrosynthesisResult = JsonConvert.DeserializeObject<RetrosynthesisResult>(responseBody);
                    return View("RetrosynthesisResult", retrosynthesisResult);
                }
                else
                {
                    return View("Error");
                }
            }
        }



























        //[HttpPost]
        //public async Task<IActionResult> SubmitReactions(string precursors)
        //{
        //    // Create an instance of HttpClient
        //    using (HttpClient client = new HttpClient())
        //    {
        //        // Construct the request body as JSON
        //        var requestBody = new { precursors };

        //        // Serialize the request body to JSON
        //        var jsonContent = JsonConvert.SerializeObject(requestBody);

        //        // Create the HTTP request message with the JSON content
        //        var request = new HttpRequestMessage(HttpMethod.Post, "https://chemgeek.live/reactions")
        //        {
        //            Content = new StringContent(jsonContent, Encoding.UTF8, "application/json")
        //        };

        //        // Send the POST request
        //        HttpResponseMessage response = await client.SendAsync(request);

        //        // Check if the request was successful
        //        if (response.IsSuccessStatusCode)
        //        {
        //            // Read the response content as string
        //            string jsonResponse = await response.Content.ReadAsStringAsync();

        //            // Pass the response body to the view
        //            return View("PostReactions", jsonResponse);
        //        }
        //        else
        //        {
        //            // Handle the API request failure
        //            // For example, return an error view or display an error message
        //            return View("Error");
        //        }
        //    }
        //}









































































    }

}


        //public async Task<IActionResult> GetCompoundData()
        //{
        //    // Create an instance of HttpClient
        //    using (HttpClient client = new HttpClient())
        //    {
        //        // Make the GET request to the API
        //        string apiUrl = "https://chemgeek.live/compounds/H2O";
        //        HttpResponseMessage response = await client.GetAsync(apiUrl);

        //        // Check if the request was successful
        //        if (response.IsSuccessStatusCode)
        //        {
        //            // Read the response content as string
        //            string jsonResponse = await response.Content.ReadAsStringAsync();

        //            // Deserialize the JSON response
        //            var compoundData = JsonConvert.DeserializeObject<CompoundData>(jsonResponse);

        //            // Pass the compoundData to the view
        //            return View(compoundData);
        //        }
        //        else
        //        {
        //            // Handle the API request failure
        //            // For example, return an error view or display an error message
        //            return View("Error");
        //        }
        //    }
        //}
