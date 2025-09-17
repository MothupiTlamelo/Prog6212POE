using System;

namespace CMCS.Models
{
    public class ApprovalRecord
    {
        public int ApprovalId { get; set; }
        public int ClaimId { get; set; }
        public string Role { get; set; } // Coordinator or Manager
        public string Decision { get; set; } // Approved or Rejected
        public DateTime DecisionAt { get; set; }
        public string Comment { get; set; }
    }
}

