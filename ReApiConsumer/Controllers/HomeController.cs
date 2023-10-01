using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReApiConsumer.Models;
using ReApiConsumer.Models.Interfaces;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace ReApiConsumer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApiResponse<Messages> _api = new ApiResponse<Messages>();
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Show()
        {
            ApiResponse<Messages> api = new ApiResponse<Messages>();

            var messages = await api.Get("api/Messages/GetMessages");
            if (messages != null) 
                return View(messages);

            return View();
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}