﻿using System.ComponentModel.DataAnnotations;

namespace DigiGall.Models
{
    public class Transaction
    {
        // global (available for all user)
        public string Id { get; set; } = default!;

        public string AdminId { get; set; } = default!;
        public string UserId { get; set; } = default!;

        public string Category { get; set; } = default!; // EXPENSE / INCOME
        public string Status { get; set; } = default!;
        protected string Type { get; set; } = default!;

        public int Amount { get; set; } = 0;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime CompletionDate { get; set; } = default!;

    }
}