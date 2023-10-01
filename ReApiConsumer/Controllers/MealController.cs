using Microsoft.AspNetCore.Mvc;
using ReApiConsumer.Models;
using ReApiConsumer.Models.Interfaces;

namespace ReApiConsumer.Controllers
{
    public class MealController : Controller
    {
        private ApiResponse<Meal> _api = new ApiResponse<Meal>();
        public MealController()
        {
        }

        public async Task<IActionResult> GetMeals()
        {
            
            var response = await _api.Get("api/Meal/GetMeals");

            if (response != null)
                return View(response);
            return View();
        }

        public async Task<IActionResult> DeleteMeal(int id)
        {

            return View();
        }
    }
}
