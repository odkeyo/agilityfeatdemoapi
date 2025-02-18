using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public DateTime Date { get; set; } = DateTime.UtcNow;

        public string Description { get; set; }
    }
}
