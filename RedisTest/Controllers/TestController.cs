using Microsoft.AspNetCore.Mvc;
using RedisTest.Global;
using StackExchange.Redis;
using System.Diagnostics;

namespace AspNetCore6DefultSetting.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class TestController : ControllerBase
	{
        /// <summary>
        /// 무조건 성공
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SuccessCall()
        {
            ObjectResult apiresult = new ObjectResult(200);

            IDatabase db = GlobalStatic.redis.GetDatabase();
            string sResult = db.StringGet("mykey2");
            if (true == string.IsNullOrEmpty(sResult))
            {//입력
                db.StringSet("mykey2", "asdfa223232");
                sResult = db.StringGet("mykey2");
            }

            apiresult = StatusCode(200, "성공! " + sResult);

            return apiresult;
        }

        [HttpGet]
        public ActionResult? RedisCall(string sMsg)
        {
            ISubscriber sub = GlobalStatic.redis.GetSubscriber();
            sub.Publish("messages", sMsg);

            return new ObjectResult(200);
        }

        [HttpGet]
        public ActionResult? Subscriber1()
        {
            ISubscriber sub = GlobalStatic.redis.GetSubscriber();
            sub.Subscribe("messages").OnMessage(channelMessage => {
                Debug.WriteLine("Subscriber1 : " + (string)channelMessage.Message);
            });

            sub.Publish("messages", "asdfasdfffff3434");

            return new ObjectResult(200);
        }

        [HttpGet]
        public ActionResult? Subscriber2()
        {
            ISubscriber sub = GlobalStatic.redis.GetSubscriber();
            sub.Subscribe("messages", (channel, message) => {
                Debug.WriteLine("Subscriber2 : " + (string)message);
            });

            return new ObjectResult(200);
        }

        
    }
}
