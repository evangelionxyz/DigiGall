using System.ComponentModel.DataAnnotations;

namespace DigiGall.Models
{
    public class Transaction : ModelBase
    {
        // global (available for all user)
        public string AdminId { get; set; } = default!;
        public string UserId { get; set; } = default!;
        public string TargetId { get; set; } = default!;
        public string Status { get; set; } = default!;
        public string Type { get; set; } = default!; // prefect/quest
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public int Amount { get; set; } = default!;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime CompletionDate { get; set; } = default!;

        public Transaction()
            : base()
        {
        }

        public Transaction(string targetId, string type)
            : base()
        {
            TargetId = targetId;
            Type = type;
        }
    }
}
