//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using ClassLibrary1.Interfaces;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//
//namespace saraproject.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class WeatherForecastController : ControllerBase
//    {
//        private static readonly string[] Summaries = new[]
//        {
//            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//        };
//
//        private readonly ILogger<WeatherForecastController> _logger;
//        private readonly IInfoService _infoService;
//
//        public WeatherForecastController(ILogger<WeatherForecastController> logger, IInfoService service)
//        {
//            _logger = logger;
//            _infoService = service;
//        }
//
//        [HttpGet]
//        public IEnumerable<WeatherForecast> Get()
//        {
//            var rng = new Random();
//            var zalp = _infoService.GetAllInfo();
//            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
//                {
//                    Date = DateTime.Now.AddDays(index),
//                    TemperatureC = rng.Next(-20, 55),
//                    Summary = Summaries[rng.Next(Summaries.Length)]
//                })
//                .ToArray();
//        }
//    }
//}