using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApplication1.Controllers
{
	[ApiController]
	[Route("api/test")]
	public class TestController : Controller
	{
		[HttpGet]
		public bool Get([FromQuery] int Equal, [FromQuery] Filter filter)
		{
			if (null == filter)
			{
				filter = new Filter();
			}

			filter.Equal = Equal;

			return true;
		}
	}


}
