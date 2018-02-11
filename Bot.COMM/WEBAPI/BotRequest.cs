using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.COMM
{
    
    public  class CreateBotRequest
    {
        public BotProfileDto BotProfile { get; set; }
        public List<NodeDto> Nodes { get; set; }
        public QueueDto Queue { get; set; }
    }

    public class BotRequest
    {
        public int BotId { get; set; }

    }
    public class StartBotRequest : BotRequest { };

    public class StopBotRequest : BotRequest { };

    public class DrainBotRequest : BotRequest { };

}
