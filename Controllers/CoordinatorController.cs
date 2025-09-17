using Microsoft.AspNetCore.Mvc;
using CMCS.Models;
using System.Collections.Generic;
using System.Linq;

namespace CMCS.Controllers
{
    public class CoordinatorController : Controller
    {
        // Reference the in-memory claim list from LecturerController
        private static List<Claim> _claims => LecturerController._claims;

        // GET: Coordinator
        public IActionResult Index()
        {
            return View(_claims);
        }

        // GET: Coordinator/Details/{id}
        public IActionResult Details(int id)
        {
            var claim = _claims.FirstOrDefault(c => c.ClaimId == id);
            if (claim == null) return NotFound();
            return View(claim);
        }

        // POST: Coordinator/Approve/{id}
        [HttpPost]
        public IActionResult Approve(int id)
        {
            var claim = _claims.FirstOrDefault(c => c.ClaimId == id);
            if (claim != null)
            {
                claim.Status = "Approved";
                TempData["Message"] = $"Claim #{id} has been approved.";
            }
            return RedirectToAction("Index");
        }

        // POST: Coordinator/Reject/{id}
        [HttpPost]
        public IActionResult Reject(int id)
        {
            var claim = _claims.FirstOrDefault(c => c.ClaimId == id);
            if (claim != null)
            {
                claim.Status = "Rejected";
                TempData["Message"] = $"Claim #{id} has been rejected.";
            }
            return RedirectToAction("Index");
        }
    }
}



