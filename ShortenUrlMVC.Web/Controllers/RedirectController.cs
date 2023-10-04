using Microsoft.AspNetCore.Mvc;
using ShortenUrlMVC.BuisnessLogic.Managers;

namespace ShortenUrlMVC.Web.Controllers
{
    [Route("[controller]")]
    public class RedirectController : ControllerBase
    {
        private readonly IShortUrlManager urlManager;

        public RedirectController(IShortUrlManager urlManager)
        {
            this.urlManager = urlManager;
        }

        [HttpGet("{shortcut}")]
        public async Task<IActionResult> GetByShortcut(string shortcut)
        {
            var url = await urlManager.GetFullUrlByShortcut(shortcut);
            return Redirect(url);
        }
    }
}
