using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoligKø.Domain.Model;
using BoligKø.Infrastructure.Commands;
using BoligKø.Infrastructure.context;
using BoligKø.Infrastructure.patterns;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BoligKø.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly AnsøgerCommand command;
        private readonly AnsøgningCommand ansøgningCommand;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, AnsøgerCommand command, AnsøgningCommand ansøgningCommand)
        {
            _logger = logger;
            this.command = command;
            this.ansøgningCommand = ansøgningCommand;
        }

        [HttpGet]
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

        [HttpGet]
        [Route("/test")]
        public async Task<string> Test()
        {
            var ansøger = await command.GetByIdIncludingAsync("1", t => t.Ansøgninger);
            var ansøgningIds = new List<string>();
            foreach (var ansøgning in ansøger.Ansøgninger)
                ansøgningIds.Add(ansøgning.Id);

            foreach(var id in ansøgningIds)
            {
                var ansøgning = await ansøgningCommand.GetByIdAsync(id);
                await ansøgningCommand.DeleteAsync(ansøgning);
            }

            await command.DeleteAsync(ansøger);

            return "doing";
        }

    }
}
