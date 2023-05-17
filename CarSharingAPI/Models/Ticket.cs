namespace CarSharingAPI.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string StartingPosition { get; set; } = string.Empty;
        public string EndingPosition { get; set; } = string.Empty;
        public int Cost { get; set; }
        public User Owner { get; set; }
        public int UserId { get; set; }
        public int PassengerId { get; set; }
        public DateTime Date { get; set; }
    }
}
