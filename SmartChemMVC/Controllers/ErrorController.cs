using Microsoft.AspNetCore.Mvc;

namespace SmartChemMVC.Controllers
{
    public class ErrorController : Controller
    {
        [Route("/error/{statusCode}")]
        public IActionResult Error(int statusCode)
        {
            return View(statusCode);
        }
    }

}
