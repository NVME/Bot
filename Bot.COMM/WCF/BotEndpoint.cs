using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace Bot.COMM
{
    [DataContract]
    public class BotConfig
    {
       
        [DataMember]
        public BotProfileDto BotProfile { get; set; }
        [DataMember]
        public List<NodeDto> Nodes { get; set; }
        [DataMember]
        public QueueDto Queue { get; set; }
    }

   
}
