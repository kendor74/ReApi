using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReApiConsumer.Models;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace ReApiConsumer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //HttpClientHandler clientHandler = new HttpClientHandler();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            //clientHandler.ServerCertificateCustomValidationCallback =
            //    { sender , cert ,chain ,sslPolicyErrors} => { return true; };
        }

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
            string url = "http://localhost:8888";
            List<Messages> messages = new List<Messages>();


            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/Messages/GetMessages");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    messages = JsonConvert.DeserializeObject<List<Messages>>(EmpResponse);
                }


            }
            //List<Messages> messages = new List<Messages>();
            //using (var client = new HttpClient())
            //{
            //    using (var responce = await client.GetAsync("http://localhost:44384/api/Messages/GetMessages"))
            //    {
            //        if (responce.IsSuccessStatusCode)
            //        {
            //            string api = await responce.Content.ReadAsStringAsync();
            //            messages = JsonConvert.DeserializeObject<List<Messages>>(api);
            //        }
            //    }
            //}

            return View(messages);
        }


        public async Task<IActionResult> Catigories()
        {
            string url = "http://localhost:8888";
            List<Catigory> catigories = new List<Catigory>();


            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/Catigory/GetCatigories");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    catigories = JsonConvert.DeserializeObject<List<Catigory>>(EmpResponse);
                }


            }
            return View(catigories);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}