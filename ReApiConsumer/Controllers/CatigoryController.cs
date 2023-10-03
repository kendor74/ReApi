using Microsoft.AspNetCore.Mvc;
using ReApiConsumer.Models;
using ReApiConsumer.Models.DTOs;

namespace ReApiConsumer.Controllers
{
    public class CatigoryController : Controller
    {
        private ApiResponse<Catigory , CatigoryDto> _api = new ApiResponse<Catigory , CatigoryDto>();
        

        public async Task<IActionResult> Catigories()
        {

            var result = await _api.Get("api/Catigory/GetCatigories");

            return (result != null) ? View(result) : View();
        }

        public async Task<IActionResult> CatigoryDetails(int id)
        {

            var result = await _api.GetById($"api/Catigory/{id}");

            return (result != null) ? View(result) : View();
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _api.GetById($"api/Catigory/{id}");
            return (result != null ? View(result) : RedirectToAction("~/Catigory/Catigories"));
        }
        
        
        [HttpPost]
        public async Task<IActionResult> DeleteCatigory(int id)
        {
            var result = await _api.Delete($"api/Catigory/{id}");

            return (result != null ? RedirectToAction($"~/Catigory/Delete/{id}") : RedirectToAction($"~/Catigory/Catigories"));
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _api.GetById($"api/Catigory/{id}");

            return (result != null) ? View(result) : RedirectToAction("~/Catigory/Catigories");
        }
        //need DTOs

        [HttpPost]
        public async Task<IActionResult> EditCatigory(Catigory catigory)
        {
            CatigoryDto dto = new CatigoryDto();
            dto.Name = catigory.Name;
            var result = await _api.Update($"api/Catigory/{catigory.Id}", dto);
            return (result != null ? RedirectToAction($"~/Catigory/CatigoryDetails/{catigory.Id}") : RedirectToAction("Error"));
        }

        //need Dto
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCatigory(CatigoryDto dto)
        {
            ViewBag.Error("Creation Denied");
            var result = await _api.Create("api/Catigory" , dto);
            
            return (result != null ? RedirectToAction($"~/Catigory/Catigories") : RedirectToAction("Create" , "Catigory"));
        }
    }
}
