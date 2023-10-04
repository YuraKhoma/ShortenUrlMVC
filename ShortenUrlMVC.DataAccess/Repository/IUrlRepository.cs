using ShortenUrlMVC.DataAccess.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortenUrlMVC.DataAccess.Repository
{
    public interface IUrlRepository: IRepository<ShortUrl>
    {
        Task<string> GetByShortcut(string shortcut);

        Task<List<ShortUrl>> GetByOwner(string owner);

        int GetIdByShortcut(string shortcut);
    }
}
