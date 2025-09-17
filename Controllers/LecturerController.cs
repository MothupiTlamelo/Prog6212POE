using Microsoft.AspNetCore.Mvc;
using CMCS.Models;
using System.Collections.Generic;

namespace CMCS.Controllers
{
    public class LecturerController : Controller
    {
        // Public static list to share with other controllers
        public static List<Claim> _claims = new List<Claim>();

        // GET: Lecturer/Submit
        public IActionResult Submit()
        {
            return View();
        }

        // POST: Lecturer/Submit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Submit(Claim claim)
        {
            if (ModelState.IsValid)
            {
                claim.ClaimId = _claims.Count + 1;
                claim.Status = "Pending";

                // TotalAmount is automatically calculated in the model
                _claims.Add(claim);
                TempData["Message"] = "Claim submitted successfully!";
                return RedirectToAction("Submit");
            }

            return View(claim);
        }
    }
}
