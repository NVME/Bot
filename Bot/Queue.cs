using System;
using System.Collections.Generic;
using Bot.COMM;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Core
{
    public class Queue
    {
        public int QueueId { get; set; }
        public string EnglishName { get; set; }
        public string CustomerId { get; set; }
        public HoursOfOperation HoursOfOperation { get; set; }
        public List<string> SupportedLanguages { get; set; } // list of language code
    }
    public class Avaya : Queue
    {
        public string SIP { get; set; }
        public string BackupSIP { get; set; }
    }

    public class ServiceNow : Queue { }

    
}
