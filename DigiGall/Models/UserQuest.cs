namespace DigiGall.Models
{
    public class UserQuest : ModelBase
    {
        // per user quest (individual quest)
        public string TargetId { get; set; } = default!;
        public string UserId { get; set; } = default!;
        public string Status { get; set; } = default!;

        public UserQuest()
            : base()
        {
        }

        public UserQuest(string targetId, string status, string userId)
            : base()
        {
            TargetId = targetId;
            Status = status;
            UserId = userId;
        }

        public UserQuest(string id, string targetId, string status, string userId)
            : base(id)
        {
            TargetId = targetId;
            Status = status;
            UserId = userId;
        }
    }
}
