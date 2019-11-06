using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary1.EF;
using ClassLibrary1.Entities;
using ClassLibrary1.Interfaces;
using Microsoft.EntityFrameworkCore;
using Object = ClassLibrary1.Entities.Object;

namespace ClassLibrary1.Repositories
{
    public class InfoRepository : IRepository<Object>
    {
        private MainInfoContext _db;

        public InfoRepository(MainInfoContext context)
        {
            _db = context;
        }
        
        public IEnumerable<Object> GetAll()
        {
            return _db.Objects;
        }
 
        public Object Get(int id)
        {
            return _db.Objects.Find(id);
        }
 
        public void Create(Object @object)
        {
            _db.Objects.Add(@object);
        }
 
        public void Update(Object @object)
        {
            _db.Entry(@object).State = EntityState.Modified;
        }
 
        public IEnumerable<Object> Find(Func<Object, Boolean> predicate)
        {
            return _db.Objects.Where(predicate).ToList();
        }
 
        public void Delete(int id)
        {
            Object book = _db.Objects.Find(id);
            if (book != null)
                _db.Objects.Remove(book);
        }
        
    }
}