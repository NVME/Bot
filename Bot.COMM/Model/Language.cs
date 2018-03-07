using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bot.COMM
{
    [DataContract]
    public  class Language
    {
        [DataMember]
        public int LanguageId { get; set; }
        [DataMember]
        public string  EnglishName { get; set; }
        [DataMember]
        public string LocalName { get; set; }
        [DataMember]
        public string LanguageCode { get; set; }
        [DataMember]
        public List<string> keywords { get; set; }
    }
    [DataContract]
    public class LanguageOptionDto
    {
        [DataMember]
        public Language Language { get; set; }
        [DataMember]
        public int TargetNodeId { get; set; }
        [DataMember]
        public string LanguageAltText { get; set; }
        [DataMember]
        public List<string> Keywords { get; set; }
    }
}
