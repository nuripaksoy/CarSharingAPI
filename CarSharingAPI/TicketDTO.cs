namespace CarSharingAPI
{
    public class TicketDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string StartingPosition { get; set; } = string.Empty;
        public string EndingPosition { get; set; } = string.Empty;
        public int Cost { get; set; }
        public int OwnerID { get; set; }
        public int PassengerId { get; set; }
        public DateTime Date { get; set; }
    }
}
