using Microsoft.AspNetCore.Mvc;
using Task1.Entities;

namespace Task1.Controllers
{
    [ApiController]
    [Route( "[controller]/[Action]" )]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController( ILogger<WeatherForecastController> logger )
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range( 1 , 5 ).Select( index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays( index ) ,
                TemperatureC = Random.Shared.Next( -20 , 55 ) ,
                Summary = Summaries[Random.Shared.Next( Summaries.Length )]
            } )
            .ToArray();
        }
        [HttpPost]
        public async Task<IActionResult> SaveParsedExcel([FromBody] List<TargetWarmBuyers> buyers )
        {
            try
            {
                await new BuyerManager().SaveTargetWarmBuyerAsync( buyers );
                return Ok();

            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}