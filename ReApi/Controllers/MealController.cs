
namespace ReApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly IRepo<Meal, MealDto> _meal;
        protected List<string> Extentions = new List<string> { ".jpg", ".png" };
        protected long posterLength = 1048576;
       
        public MealController(IRepo<Meal , MealDto> meal)
        {
            _meal = meal;
        }

        private bool IsValidExtention(MealDto DtoImage)
        {
            return Extentions.Contains(Path.GetExtension(DtoImage.Image.FileName).ToLower());
        }
        private bool IsValidPosterLength(MealDto DtoMeal)
        {
            if (DtoMeal.Image.Length > posterLength)
                return false;
            return true;
        }


        [HttpGet]
        public async Task<IActionResult> GetMeals()
        {
            return Ok(await _meal.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMeal(int id)
        {
            if (!await _meal.IsExist(id))
                return BadRequest("Invalid Id !");

            return Ok(await _meal.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddMeal(MealDto mealDto)
        {
            if (mealDto is null)
                return BadRequest("Invalid data");

            return Ok(await _meal.Add(mealDto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(MealDto mealDto , int id)
        {
            if (!await _meal.IsExist(id))
                return BadRequest("Invalid Meal Id !");
            if (!await _meal.IsExist(id))
                return BadRequest("Invalid Catigory Id !");
            if (mealDto is null)
                return BadRequest("Invalid Data !");
            if (!IsValidExtention(mealDto))
                return BadRequest("Invalid Image Extention, please let it Jpg or Png");
            if (!IsValidPosterLength(mealDto))
                return BadRequest("Image is too big , please choose another !");

            return Ok(_meal.Update(mealDto, id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeal(int id)
        {
            if (!await _meal.IsExist(id))
                return BadRequest("The Id is not Exist !");

            return Ok(await _meal.Delete(id));
        }
    }
}
