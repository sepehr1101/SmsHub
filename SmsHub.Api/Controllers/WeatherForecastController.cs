using Microsoft.AspNetCore.Mvc;
using SmsHub.Infrastructure.BaseHttp.Client.Contracts;
using SmsHub.Infrastructure.Providers.Kavenegar.Http.Contracts;

namespace SmsHub.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IRestClient _restService;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IKavenegarHttpDateService _configService;
        private string _apiKey = "5575426A68495063786333776662677171397533775377746A5A696475386159574332463078442F7750553D";

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(//ILogger<WeatherForecastController> logger,
            IHttpClientFactory httpClientFactory
            , IRestClient restClient
            , IKavenegarHttpDateService configService
            /*IRestClient configService*/)
        {
            //_logger = logger;
            _httpClientFactory = httpClientFactory;
            _configService = configService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost(Name = "Test")]
        public async Task<ActionResult> Test()
        {            
            var result = await _configService.GetCurrentDateTime(_apiKey);
            return Ok(result);
        }
    }
}