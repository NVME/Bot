using System;
using System.Collections.Generic;
using Bot.COMM;

namespace Bot.Core
{
    public class ServiceSetting
    {
        public string ApiBaseURL { get; set; }// string URL for API calls.

        public bool ProactiveCallManagerActive { get; set; }//Determines if the proactive call manager should be started.

        public int ProactiveCallInterval { get; set; } //Time in seconds between polling requests. Default is 5.

        public Alias ProactiveCallAlias { get; set; } //Alias to place outbound calls with. (optional)
        public ServiceSetting()
        {
            this.ProactiveCallInterval = 5;
        }
    }

    public class WatsonVirtualAgentSettings : ServiceSetting
    {
        public List<Header> SecurityHeaders { get; set; } // Headers for id and secret for API security.
        public WatsonVirtualAgentSettings() : base() { }
    }

    public class MicrosoftVirtualAgentSettings : ServiceSetting
    {
        public List<Language> SupportedLanguages { get; set; }//List of languages that the bot supports.
        public bool LanguageAutoDetect { get; set; } // Determines if the bot will attempt to automatically detect the user's language by leveraging a CWE.
        public string CweGuid { get; set; }//Guid for a CWE visual component.	
        public bool CweAutoStart { get; set; }//  Determines if the CWE will open automatically when the conversation starts.Default is true. Only applies when a CweGuid is provided.Is always true if LanguageAutoDetect is true.			
        public MicrosoftVirtualAgentSettings() : base() { }
    }
}
