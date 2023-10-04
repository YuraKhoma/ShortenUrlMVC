using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShortenUrlMVC.BuisnessLogic.DTO;
using ShortenUrlMVC.BuisnessLogic.Managers;
using ShortenUrlMVC.Web.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace ShortenUrlMVC.Web.Controllers
{
    [Authorize]
    public class ShortUrlController : Controller
    {
        private readonly IShortUrlManager urlManager;

        public ShortUrlController(IShortUrlManager urlManager)
        {
            this.urlManager = urlManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            return View(await urlManager.GetUrlsByOwner(userId));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ShortUrlDto shortUrlDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await urlManager.AddFullUrl(
                    shortUrlDto.Shortcut,
                    shortUrlDto.FullUrl,
                    userId);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string shortcut)
        {
            await urlManager.DeleteUrl(shortcut);

            return RedirectToAction(nameof(Index));
        }
    }
}
