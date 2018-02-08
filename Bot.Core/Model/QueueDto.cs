using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bot.COMM
{
    [DataContract]
    public class QueueDto:Dto
    {
        [DataMember]
        public int Id { get; set; }        
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string CustomerId { get; set; }
        [DataMember]
        public HoursOfOperation HoursOfOperation { get; set; }
        [DataMember]
        public List<string> SupportedLanguages { get; set; }// list of language code
        [DataMember]
        public string SIP { get; set; }
        [DataMember]
        public string BackupSIP { get; set; }

    }
}
