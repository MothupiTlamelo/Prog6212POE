namespace CMCS.Part2.Models
{
    public class Lecturer
    {
        public int Id { get; set; } = 0;       // Changed from Guid to int
        public string Name { get; set; } = string.Empty;
        public string IdNumber { get; set; } = string.Empty;
    }
}
