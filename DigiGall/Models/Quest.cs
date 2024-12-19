namespace DigiGall.Models
{
    public class Quest : ModelBase
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int Reward { get; set; } = 0;
        public string Status { get; set; } = default!;

        public Quest()
            : base()
        {
        }

        public Quest(string title, string desc, int reward)
           : base()
        {
            Title = title;
            Description = desc;
            Reward = reward;
            Status = "Available";
        }

        public Quest(string title, string desc, int reward, string status)
            : base()
        {
            Title = title;
            Description = desc;
            Reward = reward;
            Status = status;
        }

        public Quest(string id, string title, string desc, int reward, string status)
            : base(id)
        {
            Title = title;
            Description = desc;
            Reward = reward;
            Status = status;
        }
    }
}
