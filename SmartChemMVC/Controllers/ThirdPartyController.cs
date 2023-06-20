using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Xml;

namespace SmartChemMVC.Controllers
{
    public class ThirdPartyController : Controller
    {
        public IActionResult Index(string element1, string element2)
        {
            // Validate the input
            if (string.IsNullOrEmpty(element1) || string.IsNullOrEmpty(element2))
            {
                ViewBag.Error = "Please provide valid chemical elements.";
                return View();
            }

            // Combine the elements to create the chemical equation
            string equation = $"{element1} + {element2}";

            // Replace "APPID" with your actual Wolfram|Alpha AppID
            string appId = "9KHPHA-JK6A2KW85P";

            // Create a new WebClient object
            WebClient client = new WebClient();

            // Set the URL of the API request
            string url = $"http://api.wolframalpha.com/v2/query?appid={appId}&input={Uri.EscapeDataString(equation)}&format=plaintext";

            try
            {
                // Make the API request and get the response
                string response = client.DownloadString(url);

                // Parse the response and extract the solution and compound image URL
                string solution = ParseSolution(response);
                string compoundImageUrl = GetCompoundImageUrl(solution);

                // Pass the solution and compound image URL to the view
                ViewBag.Solution = solution;
                ViewBag.CompoundImageUrl = compoundImageUrl;
            }
            catch (WebException ex)
            {

                ViewBag.Error = "An error occurred while accessing the API: " + ex.Message;
            }

            return View();
        }

        private static string ParseSolution(string response)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(response);

            // Find the pod with title 'Sample reactions'
            XmlNode reactionsPod = doc.SelectSingleNode("//pod[@title='Sample reactions']");

            if (reactionsPod != null)
            {
                // Get the plaintext content of the subpod.
                XmlNode subpod = reactionsPod.SelectSingleNode("subpod");
                string solution = subpod.SelectSingleNode("plaintext")?.InnerText;

                if (!string.IsNullOrEmpty(solution))
                {
                    // Find the pod with title 'Substance properties'
                    XmlNode propertiesPod = doc.SelectSingleNode("//pod[@title='Substance properties']");

                    if (propertiesPod != null)
                    {
                        // Get the content of the subpod.
                        XmlNode propertiesSubpod = propertiesPod.SelectSingleNode("subpod");
                        string properties = propertiesSubpod.SelectSingleNode("plaintext")?.InnerText;

                        if (!string.IsNullOrEmpty(properties))
                        {
                            return $"{solution}\n\n{properties}";
                        }
                    }

                    return solution;
                }
            }

            return "Solution not found.";
        }

        private static string GetCompoundImageUrl(string solution)
        {
            try
            {
                // Extract the compound name from the solution
                int startIndex = solution.IndexOf("⟶") + 1;
                int endIndex = solution.IndexOf("|") - 1;
                string compoundName = solution.Substring(startIndex, endIndex - startIndex).Trim();

                // compound image URL
                string compoundImageUrl = $"https://pubchem.ncbi.nlm.nih.gov/rest/pug/compound/name/{Uri.EscapeDataString(compoundName)}/PNG";

                return compoundImageUrl;
            }
            catch (Exception ex)
            {
                // Handle the exception
                Console.WriteLine("An error occurred while constructing the compound image URL:");
                Console.WriteLine(ex.Message);
                return null;
            }
        }

    }
}
