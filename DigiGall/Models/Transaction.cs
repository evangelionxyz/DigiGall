using System.ComponentModel.DataAnnotations;

namespace DigiGall.Models
{
    public class Transaction : ModelBase
    {
        // global (available for all user)

        public string AdminId { get; set; } = default!;
        public string UserId { get; set; } = default!;
        public string Status { get; set; } = default!;
        protected string Type { get; set; } = default!; // prefect/quest

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime CompletionDate { get; set; } = default!;

        public Transaction()
            : base()
        {
        }

        public Transaction(string adminId, string userId, string status, string type)
            : base()
        {
            AdminId = adminId;
            UserId = userId;
            Status = status;
            Type = type;
        }

        public Transaction(string id, string adminId, string userId, string status, string type)
            : base(id)
        {
            AdminId = adminId;
            UserId = userId;
            Status = status;
            Type = type;
        }

    }
}
