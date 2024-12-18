namespace DigiGall.Models
{
    public class Quest
    {
        public string Id { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;

        // Completed, Rejected, UnderReview, Available
        public string Status { get; set; } = "Available";
        public int Amount { get; set; } = 0;

        public Quest()
        {
        }

        public Quest(string id, string title, string desc, int amount)
        {
            Id = id;
            Title = title;
            Description = desc;
            Amount = amount;
        }
    }
}
