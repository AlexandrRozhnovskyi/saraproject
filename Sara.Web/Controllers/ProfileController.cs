using System.Collections.Generic;
using System.Threading.Tasks;
using ClassLibrary1.Entities;
using ClassLibrary1.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using saraproject.Models;
using saraproject.Models.Request;

namespace saraproject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : ControllerBase
    {
        
        private readonly ILogger<ProfileController> _logger;
        private readonly IObjectService _objectService;

        public ProfileController(ILogger<ProfileController> logger, IObjectService objectService)
        {
            _logger = logger;
            _objectService = objectService;
        }

        [HttpGet]
        public async Task<IEnumerable<Object>> GetAllInfo()
        {
            return await _objectService.GetAllObjects();
        }
        [HttpPost]
        public async Task<ObjectDto> PostInfo([FromBody] UpdateObjectRequest objectRequest)
        {
            return await _objectService.PostObject(objectRequest);
        }
        

    }
}