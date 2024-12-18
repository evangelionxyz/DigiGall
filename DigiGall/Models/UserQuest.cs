namespace DigiGall.Models
{
    public class UserQuest
    {
        // per user quest (individual quest)
        public string Id { get; set; } = default!;
        public string TargetId { get; set; } = default!;
        public string Status { get; set; } = default!;

        public UserQuest()
        {
        }

        public UserQuest(string id, string targetId)
        {
            Id = id;
            TargetId = targetId;
            Status = "Available";
        }
    }
}
