using Microsoft.AspNetCore.Mvc;

namespace Project1.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecast2Controller : ControllerBase
{
	private static readonly string[] Summaries = new[]
	{
		"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
	};


	WeatherForecastController weatherForecastController;

	private readonly ILogger<WeatherForecastController> _logger;

	public WeatherForecast2Controller(ILogger<WeatherForecastController> logger)
	{
		_logger = logger;

		weatherForecastController
			= new WeatherForecastController(logger);

	}

	[HttpGet]
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

	[HttpGet]
	public IEnumerable<WeatherForecast> Get2()
	{
		return weatherForecastController.Get();
	}


	[HttpGet]
	public IEnumerable<WeatherForecast> Get3()
	{
		weatherForecastController.ControllerContext = this.ControllerContext;
		return weatherForecastController.Get();
	}
}