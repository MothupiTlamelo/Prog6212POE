using System;

namespace CMCS.Models
{
    public class ClaimLine
    {
        public DateTime Date { get; set; }
        public string ActivityDescription { get; set; }
        public decimal HoursWorked { get; set; }
        public decimal HourlyRate { get; set; }

        // Amount is calculated automatically
        public decimal LineAmount
        {
            get
            {
                return HoursWorked * HourlyRate;
            }
        }
    }
}
