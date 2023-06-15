using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace SmartChemMVC.Controllers
{
    public class ModelController : Controller
    {
        public IActionResult Index()
        {


            return View();
        }






    
        public async Task<ActionResult> Reactions()
        {
            string apiUrl = "https://chemgeek.live/reactions";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    return View("ChemicalReactions", json);
                }
                else
                {
                    return View("Error");
                }
            }
        }
    



}
}


//using System;
//using System.Collections.Generic;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;
//using Newtonsoft.Json;

//public static class ChemistryAPI
//{
//    public static async Task<Dictionary<string, dynamic>> ComputeReactionsAsync()
//    {
//        string apiUrl = "https://chemgeek.live/reactions";

//        Dictionary<string, string> body = new Dictionary<string, string>
//        {
//            { "precursors", "C8H8Br2 . C8H14S . C2H3N . Na+ . ClO4-" }
//        };

//        using (HttpClient client = new HttpClient())
//        {
//            client.DefaultRequestHeaders.Add("accept", "application/json");
//            client.DefaultRequestHeaders.Add("Content-Type", "application/json");

//            string jsonBody = JsonConvert.SerializeObject(body);
//            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

//            HttpResponseMessage response = await client.PostAsync(apiUrl, content);

//            if (response.IsSuccessStatusCode)
//            {
//                string responseBody = await response.Content.ReadAsStringAsync();
//                return JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(responseBody);
//            }
//            else
//            {
//                throw new Exception("Failed to compute reactions");
//            }
//        }
//    }
//}