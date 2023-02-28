using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementCore.Models;
using UserManagementCore.Models.enzan_model;

namespace UserManagementCore.Controllers
{
   // [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {

            //ApplicationRole applicationRole = new ApplicationRole();
            //applicationRole.Id = Guid.NewGuid().ToString();
            //applicationRole.Name = "Enzan4";
            //applicationRole.NormalizedName = "Enzan4";
            //applicationRole.Description = "Enzan4";

            //Company company = new Company();
            //company.CompanyName = "Test2";
            //company.CreatedDate = DateTime.Now.ToString();

            //try
            //{
            //    EF_Model.dbContext.Companies.Add(company);
            //    EF_Model.dbContext.Roles.Add(applicationRole);            
            //    EF_Model.dbContext.SaveChanges();
            //}
            //catch (Exception ex)
            //{
            //    var msg = ex.Message;
            //}
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
