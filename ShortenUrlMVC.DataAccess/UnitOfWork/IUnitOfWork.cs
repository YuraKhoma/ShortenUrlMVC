using ShortenUrlMVC.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortenUrlMVC.DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public IUrlRepository UrlRepository { get; }
        public Task SaveAsync();
    }
}
