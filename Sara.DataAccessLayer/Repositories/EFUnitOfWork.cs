using System;
using ClassLibrary1.EF;
using ClassLibrary1.Entities;
using ClassLibrary1.Interfaces;
using Microsoft.EntityFrameworkCore;
using Object = ClassLibrary1.Entities.Object;

namespace ClassLibrary1.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private MainInfoContext _db;
        private InfoRepository _repository;

        public EFUnitOfWork(DbContextOptions<MainInfoContext> options)
        {
            _db = new MainInfoContext(options);
        }

        public IRepository<Object> Objects
        {
            get
            {
                if (_repository == null)
                    _repository = new InfoRepository(_db);
                return _repository;
            }

        }

        public void Save()
        {
            _db.SaveChanges();
        }
 
        
        private bool disposed = false;
 
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
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