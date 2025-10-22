using System;

namespace CMCS.Part2.Models
{
    public class Document
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ClaimId { get; set; }
        public Claim? Claim { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string StoredFileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public long Size { get; set; }
    }
}
