using CMCS.Part2.Services;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc;

namespace CMCS.Part2.Controllers
{
    public class LecturerController : Controller
    {
        [HttpGet]
        public IActionResult Submit()
        {
            return View(); // This will look for Views/Lecturer/Submit.cshtml
        }

        [HttpPost]
        public IActionResult Submit(string lecturerName, string idNumber, int hoursWorked, decimal hourlyRate, string month, string notes)
        {
            // Simulate save logic or use your ClaimService
            ViewBag.Message = "Claim captured successfully!";
            return View();
        }
    }
}
