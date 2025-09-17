using System.Collections.Generic;

namespace CMCS.Models
{
    public static class ClaimStore
    {
        public static List<Claim> Claims { get; set; } = new List<Claim>();
        public static int NextClaimId { get; set; } = 1;
    }
}
