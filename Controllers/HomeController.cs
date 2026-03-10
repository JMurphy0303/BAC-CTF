using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CtfApp.Models;

namespace CtfApp.Controllers;

public class HomeController : Controller
{
    [Authorize]
    public IActionResult Dashboard()
    {
        var userId = int.Parse(User.FindFirst("UserId")!.Value);
        // Only show documents belonging to the logged-in user
        var myDocs = DataStore.Documents.Where(d => d.OwnerId == userId).ToList();
        return View(myDocs);
    }

    // VULNERABILITY: No ownership check — any authenticated user can retrieve
    // any document by supplying its ID. Document id=6 contains the CTF flag.
    [Authorize]
    public IActionResult ViewDocument(int id)
    {
        var doc = DataStore.Documents.FirstOrDefault(d => d.Id == id);
        if (doc == null) return NotFound();

        // Missing: var currentUserId = int.Parse(User.FindFirst("UserId")!.Value);
        // Missing: if (doc.OwnerId != currentUserId) return Forbid();

        return View(doc);
    }
}
