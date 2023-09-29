namespace ReApi.Models.Food
{
    public class MealHandler : IRepo<Meal, MealDto>
    {
        ReDbContext _db;
        protected List<string> Extentions = new List<string> { ".jpg", ".png" };
        protected long posterLength = 1048576;



        public MealHandler(ReDbContext context)
        {
            _db = context;
        }

        public async Task<Meal> Add(MealDto DtoMeal)
        {
            using var dataStream = new MemoryStream();
            await DtoMeal.Image.CopyToAsync(dataStream);
            var meal = new Meal
            {
                Name = DtoMeal.Name,
                Description = DtoMeal.Description,
                CatigoryId = DtoMeal.CatigoryId,
                Image = dataStream.ToArray()          
            };
            await _db.Meals.AddAsync(meal);
            await _db.SaveChangesAsync();
            return meal;
        }

        public async Task<bool> Delete(int id)
        {
            if (await IsExist(id))
                return false;

            _db.Meals.Remove(await FindById(id));
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Meal> GetById(int id)
        {
            return await FindById(id);
        }
        
        public async Task<IEnumerable<Meal>> GetAll()
        {
            return await _db.Meals.ToListAsync();
        }

        public async Task<Meal> Update(MealDto DtoMeal, int id)
        {
            if (!await IsExist(id))
                return null;
           
            Meal meal = await FindById(id);

            meal.Name = DtoMeal.Name;
            meal.Description = DtoMeal.Description;
            meal.CatigoryId = DtoMeal.CatigoryId;

            if (DtoMeal.Image != null)
            {
                using var dataStream = new MemoryStream();
                await DtoMeal.Image.CopyToAsync(dataStream);
                meal.Image = dataStream.ToArray();
            }

            _db.Meals.Update(meal);
            await _db.SaveChangesAsync();
            return meal;
        }


      
        public bool IsValidExtention(MealDto DtoImage)
        {
            return Extentions.Contains(Path.GetExtension(DtoImage.Image.FileName).ToLower());
        }
        public bool IsValidPosterLength(MealDto DtoMeal)
        {
            if (DtoMeal.Image.Length > posterLength)
                return false;
            return true;
        }


        public async Task<int> Count()
        {
            return await _db.Meals.CountAsync();
        }
        public async Task<Meal> FindById(int id)
        {
            return await _db.Meals.FindAsync(id);
        }
        public async Task<bool> IsExist(int id)
        {
            return await _db.Meals.AnyAsync(i => i.Id == id);
        }

       

        

        
    }
}
