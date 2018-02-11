using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.COMM
{
    public class BatchRequest
    {
        public List<string> Bots { get; set; }
    }

    public class BatchStartBotRequest : BatchRequest { };

    public class BatchStopBotRequest : BatchRequest { };

    public class BatchDrainBotRequest : BatchRequest { };
}
