using ShortenUrlMVC.BuisnessLogic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortenUrlMVC.BuisnessLogic.Managers
{
    public interface IShortUrlManager
    {
        public Task<string> GetFullUrlByShortcut(string shortcut);

        public Task AddFullUrl(string shortcut, string fullUrl, string owner);

        public Task<List<ShortUrlDto>> GetAllUrls();

        public Task<List<ShortUrlDto>> GetUrlsByOwner(string owner);

        public Task DeleteUrl(string shortcut);
    }
}
