namespace CMCS.Models
{
    public class Lecturer
    {
        public int LecturerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string IDNumber { get; set; }
        public decimal HourlyRate { get; set; }
        public string BankDetails { get; set; }
        public bool IsActive { get; set; }
    }
}
