using ShortenUrlMVC.DataAccess.Data;
using ShortenUrlMVC.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortenUrlMVC.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext db;
        private UrlRepository urlRepository;

        public UnitOfWork(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IUrlRepository UrlRepository
        {
            get
            {
                if (urlRepository == null)
                {
                    urlRepository = new UrlRepository(db);
                }

                return urlRepository;
            }
        }

        public Task SaveAsync()
        {
            return db.SaveChangesAsync();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
