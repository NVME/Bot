using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bot.COMM
{
    [DataContract]
    public class ServiceSettingDto:Dto
    {
        [DataMember]
        public int ServiceSettingId { get; set; }
        [DataMember]
        public string ApiBaseURL { get; set; }// string URL for API calls.
        [DataMember]
        public bool ProactiveCallManagerActive { get; set; }//Determines if the proactive call manager should be started.
        [DataMember]
        public int ProactiveCallInterval { get; set; } //Time in seconds between polling requests. Default is 5.
        [DataMember]
        public Alias ProactiveCallAlias { get; set; } //Alias to place outbound calls with. (optional)   
        [DataMember]
        public List<Header> SecurityHeaders { get; set; } // Headers for id and secret for API security.      
        [DataMember]
        public List<Language> SupportedLanguages { get; set; }//List of languages that the bot supports.
        [DataMember]
        public bool LanguageAutoDetect { get; set; } // Determines if the bot will attempt to automatically detect the user's language by leveraging a CWE.
        [DataMember]
        public string CweGuid { get; set; }//Guid for a CWE visual component.	
        [DataMember]
        public bool CweAutoStart { get; set; }//  Determines if the CWE will open automatically when the conversation starts.Default is true. Only applies when a CweGuid is provided.Is always true if LanguageAutoDetect is true.			
       
    }
    [DataContract]
    public class Alias { }
    [DataContract]
    public class Header { }
}
