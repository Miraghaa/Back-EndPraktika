using Microsoft.AspNetCore.Mvc;
using ProniaUI.ViewModels.AuthVMs;

namespace ProniaUI.Contorllers
{
    public class AuthController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM user)
        {
            if (!ModelState.IsValid) return View(user);
            return Ok();
    }
    }
    
}
