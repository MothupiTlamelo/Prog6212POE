using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace CMCS.Part2.Models
{
    public class ClaimInputModel
    {
        public Guid LecturerId { get; set; }

        [Range(2000, 2100)]
        public int Year { get; set; } = DateTime.UtcNow.Year;

        [Range(1, 12)]
        public int Month { get; set; } = DateTime.UtcNow.Month;

        [Required]
        [Range(1, 300)]
        public decimal HoursWorked { get; set; }

        [Required]
        [Range(100, 10000)]
        public decimal HourlyRate { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }

        public IFormFile[]? Files { get; set; }
    }
}
