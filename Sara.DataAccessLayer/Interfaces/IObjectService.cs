using System.Collections.Generic;
using System.Threading.Tasks;
using ClassLibrary1.Entities;
using saraproject.Models;
using saraproject.Models.Request;

namespace ClassLibrary1.Interfaces
{
    public interface IObjectService
    {
        Task<List<Object>> GetAllObjects();
        Task<ObjectDto> PostObject(UpdateObjectRequest objectRequest);
    }
}