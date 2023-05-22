using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
	[ApiController]
	[Route("api/[controller]/[action]")]
	public class TestController : Controller
	{
		
		[HttpGet]
		public IEnumerable<WeatherForecast> Get1()
		{
			WeatherForecastController weatherForecastController
				= new WeatherForecastController();

			return weatherForecastController.Get();
		}

		[HttpGet]
		public IEnumerable<WeatherForecast> Get2()
		{
			WeatherForecastController weatherForecastController
				= new WeatherForecastController();

			weatherForecastController.ControllerContext = this.ControllerContext;

			return weatherForecastController.Get();
		}

		[HttpGet]
		public IEnumerable<WeatherForecast> Get3()
		{
			WeatherForecastController weatherForecastController
				= new WeatherForecastController();

			weatherForecastController.ControllerContext
				= new ControllerContext(new ActionContext());

			
			return weatherForecastController.Get();
		}

	}
}
