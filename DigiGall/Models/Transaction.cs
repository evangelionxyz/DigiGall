using System.ComponentModel.DataAnnotations;

namespace DigiGall.Models
{
    public class Transaction : ModelBase
    {
        // global (available for all user)
        public string TargetId { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        protected string Type { get; set; } = default!; // prefect/quest

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
