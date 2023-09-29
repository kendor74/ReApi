namespace ReApi.Models.Food
{
    public class Meal
    {
        public int Id { get; set; }
                
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public byte[] Image { get; set; }
        
        public int CatigoryId { get; set; }
       
        public virtual Catigory Catigory { get; set; }
    }
}
