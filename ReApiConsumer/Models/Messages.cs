namespace ReApiConsumer.Models
{
    public class Messages
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string MessageDescription { get; set; }

        public string Subject { get; set; }

        public string Email { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
    }
}
