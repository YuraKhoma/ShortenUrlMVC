using ShortenUrlMVC.BuisnessLogic.DTO;
using ShortenUrlMVC.DataAccess.Data.Entities;
using ShortenUrlMVC.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortenUrlMVC.BuisnessLogic.Managers
{
    public class ShortUrlManager : IShortUrlManager
    {
        private IUnitOfWork unitOfWork;

        public ShortUrlManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task AddFullUrl(string shortcut, string fullUrl, string owner)
        {
            // add validation that shortcut is unique
            ShortUrl shortUrl = new ShortUrl
            {
                FullUrl = fullUrl,
                Short = shortcut,
                Owner = owner
            };

            unitOfWork.UrlRepository.Create(shortUrl);

            await unitOfWork.SaveAsync();
        }

        public async Task DeleteUrl(string shortcut)
        {
            var id = unitOfWork.UrlRepository.GetIdByShortcut(shortcut);

            //якусь перевірку на null

            unitOfWork.UrlRepository.Delete(id);
        }

        public async Task<string> GetFullUrlByShortcut(string shortcut)
        {
            var url = await unitOfWork.UrlRepository.GetByShortcut(shortcut);

            if (url == null)
            {
                return string.Empty;
            }

            return url;
        }

        public async Task<List<ShortUrlDto>> GetAllUrls()
        {
            var allEntities = await unitOfWork.UrlRepository.GetAll();

            // reuse this part of code
            List<ShortUrlDto> shortUrlDtos = new List<ShortUrlDto>();

            foreach (var item in allEntities)
            {
                ShortUrlDto shortUrlDto
                    = new ShortUrlDto { FullUrl = item.FullUrl, Shortcut = item.Short };


                shortUrlDtos.Add(shortUrlDto);
            }

            return shortUrlDtos;
        }

        public async Task<List<ShortUrlDto>> GetUrlsByOwner(string owner)
        {
            var allEntities = await unitOfWork.UrlRepository.GetByOwner(owner);

            List<ShortUrlDto> shortUrlDtos = new List<ShortUrlDto>();

            foreach (var item in allEntities)
            {
                ShortUrlDto shortUrlDto
                    = new ShortUrlDto { FullUrl = item.FullUrl, Shortcut = item.Short };


                shortUrlDtos.Add(shortUrlDto);
            }

            return shortUrlDtos;
        }
    }
}
