using CMCS.Part2.Models;
using CMCS.Part2.Services;
using System.Linq;
using Xunit;

namespace CMCS.Part2.Tests
{
    public class ClaimServiceTests
    {
        private ClaimService _service;

        public ClaimServiceTests()
        {
            // Initialize a fresh service for each test
            _service = new ClaimService();
        }

        [Fact]
        public void AddClaim_ShouldAddClaimToList()
        {
            // Arrange
            string lecturerName = "John Doe";
            string idNumber = "L001";
            int hoursWorked = 40;
            decimal hourlyRate = 350;
            string month = "2025-10";
            string notes = "Test claim";

            // Act
            _service.AddClaim(lecturerName, idNumber, hoursWorked, hourlyRate, month, notes);

            // Assert
            var claim = _service.GetClaims().First();
            Assert.Single(_service.GetClaims());
            Assert.Equal("Pending", claim.Status);
            Assert.Equal(lecturerName, claim.Lecturer.Name);
            Assert.Equal(idNumber, claim.Lecturer.IdNumber);
            Assert.Equal(hoursWorked, claim.HoursWorked);
            Assert.Equal(hourlyRate, claim.HourlyRate);
            Assert.Equal(hoursWorked * hourlyRate, claim.TotalAmount);
        }

        [Fact]
        public void ApproveClaim_ShouldSetStatusToApproved()
        {
            // Arrange
            _service.AddClaim("Jane Smith", "L002", 35, 300, "2025-10", "");
            var claim = _service.GetClaims().First();

            // Act
            _service.ApproveClaim(claim.Id);

            // Assert
            Assert.Equal("Approved", claim.Status);
        }

        [Fact]
        public void RejectClaim_ShouldSetStatusToRejected()
        {
            // Arrange
            _service.AddClaim("Mark Lee", "L003", 20, 250, "2025-10", "");
            var claim = _service.GetClaims().First();

            // Act
            _service.RejectClaim(claim.Id);

            // Assert
            Assert.Equal("Rejected", claim.Status);
        }

        [Fact]
        public void TotalAmount_ShouldCalculateCorrectly()
        {
            // Arrange
            _service.AddClaim("Alice Brown", "L004", 50, 400, "2025-10", "");
            var claim = _service.GetClaims().First();

            // Act
            var total = claim.TotalAmount;

            // Assert
            Assert.Equal(20000, total); // 50 * 400
        }

        [Fact]
        public void MultipleClaims_ShouldMaintainCorrectCount()
        {
            // Arrange
            _service.AddClaim("Lecturer1", "L005", 10, 100, "2025-10", "");
            _service.AddClaim("Lecturer2", "L006", 20, 200, "2025-10", "");

            // Act
            var claims = _service.GetClaims();

            // Assert
            Assert.Equal(2, claims.Count());
        }
    }
}
