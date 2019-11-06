using System;
using ClassLibrary1.Entities;
using Object = ClassLibrary1.Entities.Object;

namespace ClassLibrary1.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Object> Objects { get;}
        void Save();
    }
}