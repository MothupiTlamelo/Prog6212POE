using Microsoft.AspNetCore.Mvc;
using CMCS.Part2.Services;

namespace CMCS.Part2.Controllers
{
    public class ClaimController : Controller
    {
        private static readonly ClaimService _claimService = new ClaimService();

        // GET: Submit page
        [HttpGet]
        public IActionResult Submit()
        {
            return View();
        }

        // POST: Submit a claim
        [HttpPost]
        public IActionResult Submit(string lecturerName, string idNumber, int hoursWorked, decimal hourlyRate, string month, string notes)
        {
            _claimService.AddClaim(lecturerName, idNumber, hoursWorked, hourlyRate, month, notes);

            var total = hoursWorked * hourlyRate;
            ViewBag.Message = "Claim captured successfully!";
            ViewBag.TotalAmount = total.ToString("C");

            return View();
        }

        // GET: Pending claims
        [HttpGet]
        public IActionResult Pending()
        {
            var claims = _claimService.GetClaims();
            return View(claims); // Make sure the view is at Views/Claim/Pending.cshtml
        }

        // POST: Approve a claim
        [HttpPost]
        public IActionResult Approve(int id)
        {
            _claimService.ApproveClaim(id);
            return RedirectToAction("Pending");
        }

        // POST: Reject a claim
        [HttpPost]
        public IActionResult Reject(int id)
        {
            _claimService.RejectClaim(id);
            return RedirectToAction("Pending");
        }
    }
}
