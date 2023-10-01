namespace ReApiConsumer.Models
{
    public class Meal
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }


        public int CatigoryId { get; set; }

        public virtual Catigory Catigory { get; set; }
    }
}
