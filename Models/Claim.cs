using System;
using System.Collections.Generic;
using System.Linq;

namespace CMCS.Models
{
    public class Claim
    {
        public int ClaimId { get; set; }
        public string LecturerId { get; set; }
        public string ClaimMonth { get; set; }
        public string Status { get; set; } = "Pending";

        public List<ClaimLine> ClaimLines { get; set; } = new List<ClaimLine>();
        public List<Attachment> Attachments { get; set; } = new List<Attachment>();

        // Total amount automatically calculated
        public decimal TotalAmount => ClaimLines?.Sum(l => l.LineAmount) ?? 0;
    }
}
