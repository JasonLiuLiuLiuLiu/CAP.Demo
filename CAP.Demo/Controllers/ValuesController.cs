using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;

namespace CAP.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ICapPublisher _publisher;

        public ValuesController(ICapPublisher publisher)
        {
            _publisher = publisher;
        }

        [HttpGet]
        public string Get(string message)
        {
            //"cap.test.queue"是发送的消息RouteKey，可以理解为消息管道的名称
            _publisher.Publish("cap.test.queue",message);

            return "发送成功";
        }

        //"cap.test.queue"为发送消息时的RauteKey，也可以模糊匹配
        //详情https://www.rabbitmq.com/tutorials/tutorial-four-dotnet.html
        [CapSubscribe("cap.test.queue")]
        public void HandleMessage(string message)
        {
            Console.WriteLine(DateTime.Now.ToString()+"收到消息:"+message);
            throw new Exception("测试失败重试");
        }

    }
}
