using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API.Controllers
{
    [ApiController]
    [Route("api/WeatherForecast")]
    [ApiExplorerSettings(GroupName = "WeatherForcast")]
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

        [HttpGet("weather")]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        //[HttpGet("readtemplate")]
        //public Task<string> GetTemplate(string templatename, string to, string toName, string ccName, string cc, string mail_subject)
        //{
        //    //var data = MessageRepository.GetTextFromHtmlTemplate("vendor_invite", (new { VendorName = Name }));
        //    var data = MessageRepository.SendTemplateMail(templatename, to, toName, ccName, cc, mail_subject, new { toEmail = to, ccMail = cc, subject = mail_subject });

        //    return data;
        //}

    }
}
