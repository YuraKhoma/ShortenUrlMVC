using Microsoft.EntityFrameworkCore;
using ShortenUrlMVC.DataAccess.Data.Entities;
using ShortenUrlMVC.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortenUrlMVC.DataAccess.Repository
{
    public class UrlRepository : IUrlRepository
    {
        private readonly ApplicationDbContext db;

        public UrlRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(ShortUrl item)
        {
            this.db.Add(item);
        }

        public void Delete(int id)
        {
            ShortUrl url = db.ShortenUrls.Find(id);
            if (url != null)
            {
                db.ShortenUrls.Remove(url);
            }
        }

        public Task<ShortUrl> Get(int id)
        {
            return db.ShortenUrls.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<ShortUrl>> GetAll()
        {
            return db.ShortenUrls.ToListAsync();
        }

        public Task<List<ShortUrl>> GetByOwner(string owner)
        {
            return db.ShortenUrls.Where(x => x.Owner == owner).ToListAsync();
        }

        public Task<string> GetByShortcut(string shortcut)
        {
            return db.ShortenUrls.Where(x => x.Short == shortcut)
                .Select(x => x.FullUrl).FirstOrDefaultAsync();
        }

        public int GetIdByShortcut(string shortcut)
        {
            var record = db.ShortenUrls.Where(x => x.Short == shortcut)
                .Select(x => x.Id).FirstOrDefaultAsync();

            return record.Id;
        }

        public void Update(ShortUrl item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
