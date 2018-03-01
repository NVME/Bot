using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bot.COMM
{
    [DataContract]
    public class Customer:Setting
    {
        public string Name { get; set; }//Customer's name. For internal use only.
        public List<int> BotIds { get; set; } //One or more bots belonging to the customer.
        [DataMember]
        public GlobalPhrase GlobalDisclaimer { get; set; }
    }
}
