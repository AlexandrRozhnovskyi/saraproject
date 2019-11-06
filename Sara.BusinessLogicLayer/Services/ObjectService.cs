using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClassLibrary1.DataTransferObjects;
using ClassLibrary1.EF;
using ClassLibrary1.Interfaces;
using Ninject.Activation;
using saraproject.Models;
using saraproject.Models.Request;
using Object = ClassLibrary1.Entities.Object;

namespace ClassLibrary1.Services
{
    public class ObjectService : IObjectService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        private readonly MainInfoContext _context;

        public ObjectService(IUnitOfWork db, IMapper mapper, MainInfoContext context)
        {
            _db = db;
            _mapper = mapper;
            _context = context;
        }
        
        public async Task<List<Object>> GetAllObjects()
        {
            var allObjects = _db.Objects.GetAll().ToList();
            return allObjects;
        }

        public async Task<ObjectDto> PostObject(UpdateObjectRequest objectRequest)
        {
            var newObject = new Object
            {
                Id = 1,
                
                City = objectRequest.City,
                
                House = objectRequest.House,
                
                Name = objectRequest.Name,
                
                Street = objectRequest.Street,
                
                MapCoordinates = objectRequest.MapCoordinates,
                
                Info = objectRequest.Info
            };
//
//            _db.Objects.Update(newObject);
//            _db.Save();

            _context.Objects.Add(newObject);
            await _context.SaveChangesAsync();

            var zalupa = _mapper.Map<ObjectDto>(newObject);
            
            return zalupa;
        }
    }
}