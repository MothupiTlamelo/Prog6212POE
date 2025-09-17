using Microsoft.AspNetCore.Mvc;
using CMCS.Models;
using System.Collections.Generic;
using System.Linq;

namespace CMCS.Controllers
{
    public class ManagerController : Controller
    {
        // Access public static _claims from LecturerController
        private static List<Claim> _claims => LecturerController._claims;

        // GET: Manager
        public IActionResult Index()
        {
            // Only approved claims
            var approvedClaims = _claims.Where(c => c.Status == "Approved").ToList();
            return View(approvedClaims);
        }

        // GET: Manager/Details/{id}
        public IActionResult Details(int id)
        {
            var claim = _claims.FirstOrDefault(c => c.ClaimId == id);
            if (claim == null) return NotFound();
            return View(claim);
        }
    }
}

