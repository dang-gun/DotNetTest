
using EntityFrameworkSample.DB.Models;
using Microsoft.AspNetCore.Mvc;


namespace SPA_NetCore_Foundation.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Call()
        {

            using (ModelsDbContextModel db1 = new ModelsDbContextModel())
            {
                TestOC1? findItem = db1.TestOC1.Where(w => w.idTestOC1 == 1).FirstOrDefault();

                if (findItem != null)
                {

                }
            }

            return StatusCode(StatusCodes.Status200OK);
        }

    }
}