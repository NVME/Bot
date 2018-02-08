using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Bot.COMM;


namespace Bot.Master
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BotController : ApiController
    {
        [HttpPost]
        public void Create(CreateBotRequest request)
        {
            var profile = request.BotProfile;
            var menu = NodeList.GetList();
            var queue = request.Queue;
            Master.Create(profile, menu, queue);
        }

        [HttpPost]
        public void Start(StartBotRequest request)
        {
            Master.Start(request.BotId);
        }

        [HttpPost]
        public void Stop(StopBotRequest request)
        {
            Master.Stop(request.BotId);
        }

        [HttpPost]
        public void Drain(DrainBotRequest request)
        {
            Master.Drain(request.BotId);
        }

        [HttpPost]
        public void Update(List<NodeDto> nodes)
        {
            var list = nodes;
        }

        [HttpPost]
        public void Notify(Notification notification)
        {
            Console.WriteLine("Message from bot:" + notification.Message);
        }

        [HttpGet]
        public string Ping()
        {
            return "Pung!";
        }
    }


}
