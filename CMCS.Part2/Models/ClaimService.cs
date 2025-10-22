using CMCS.Part2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CMCS.Part2.Services
{
    public class ClaimService
    {
        private readonly List<Lecturer> _lecturers = new();
        private readonly List<Claim> _claims = new();
        private int _claimIdCounter = 1;

        public ClaimService()
        {
            _lecturers.Add(new Lecturer { Id = 1, Name = "John Doe", IdNumber = "L001" });
        }

        public IEnumerable<Lecturer> GetLecturers() => _lecturers;

        public IEnumerable<Claim> GetClaims() => _claims;

        public void AddClaim(string lecturerName, string idNumber, int hoursWorked, decimal hourlyRate, string month, string notes)
        {
            var claim = new Claim
            {
                Id = _claimIdCounter++,
                Lecturer = new Lecturer { Name = lecturerName, IdNumber = idNumber },
                HoursWorked = hoursWorked,
                HourlyRate = hourlyRate,
                Month = month,
                Notes = notes,
                Status = "Pending"
            };

            _claims.Add(claim);
        }

        public void ApproveClaim(int claimId)
        {
            var claim = _claims.FirstOrDefault(c => c.Id == claimId);
            if (claim != null)
                claim.Status = "Approved";
        }

        public void RejectClaim(int claimId)
        {
            var claim = _claims.FirstOrDefault(c => c.Id == claimId);
            if (claim != null)
                claim.Status = "Rejected";
        }
    }
}
