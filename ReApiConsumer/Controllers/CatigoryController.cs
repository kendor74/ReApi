using Microsoft.AspNetCore.Mvc;
using ReApiConsumer.Models;

namespace ReApiConsumer.Controllers
{
    public class CatigoryController : Controller
    {
        private ApiResponse<Catigory> _api = new ApiResponse<Catigory>();
        

        public async Task<IActionResult> Catigories()
        {
            ApiResponse<Catigory> cat = new ApiResponse<Catigory>();

            var result = await cat.Get("api/Catigory/GetCatigories");

            if(result != null) 
                return View(result);
            return View();
        }
    }
}
