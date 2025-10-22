namespace CMCS.Part2.Models
{
    public class Claim
    {
        public int Id { get; set; }
        public Lecturer Lecturer { get; set; } = new Lecturer();
        public int HoursWorked { get; set; }
        public decimal HourlyRate { get; set; }
        public string Month { get; set; } = string.Empty; // "October 2025"
        public string Notes { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending";

        // Auto-calculated total
        public decimal TotalAmount => HoursWorked * HourlyRate;
    }
}
