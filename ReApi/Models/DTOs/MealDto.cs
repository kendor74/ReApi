namespace ReApi.Models.DTOs
{
    public class MealDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IFormFile Image { get; set; }

        public int CatigoryId { get; set; }

    }
}
