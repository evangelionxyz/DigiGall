namespace DigiGall.Models
{
    public class Quest : Transaction
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;

        public Quest()
        {
            Type = "QUEST";
        }

        public Quest(string id, string title, string desc, int amount)
        {
            Id = id;
            Title = title;
            Description = desc;
            Amount = amount;
            Type = "QUEST";
        }
    }
}
