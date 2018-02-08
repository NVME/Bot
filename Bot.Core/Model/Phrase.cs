using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bot.COMM
{
    [DataContract]
    public class GlobalPhrase
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public List<LocalPhrase> Phrases { get; set; }
    }
    [DataContract]
    public class LocalPhrase
    {
        [DataMember]
        public string LanguageCode { get; set; }
        [DataMember]
        public string Text { get; set; }
    }
}
