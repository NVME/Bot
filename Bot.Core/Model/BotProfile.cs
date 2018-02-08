using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.COMM
{
    public abstract class BotProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }//Descriptive name for the bot. Internal use only.
        public List<string> BotSIP { get; set; }//List of Application Endpoints to register as bots. There will only be multiple items if the SplitEndpoints attribute is set to true.
        public int InactivityTimeout { get; set; } //Overrides the default conversation timeout with  a new timeout. Value is in minutes. (optional) Default is 20 minutes. Use 0 for no override.
        public int MobileInactivityTimeout { get; set; }//Overrides the default conversation timeout on mobile clients with  a new timeout. Value is in minutes. (optional) Default is 20 minutes. Use 0 for no override.
        public string CustomerId { get; set; }//The customer who owns the bot.
        public string DefaultLanguage { get; set; }//Default language for system messages prior to language selection.
        public string SystemTextSettings { get; set; }//Overrides some or all of the default system messages with custom text.
        public string AgentSystemTextSettings { get; set; }//Overrides some or all of the system messages from the service desk with custom text.

    }

    public class InteractiveResponse:BotProfile
    {
        public List<string> SupportedLanguages { get; set; }//List of languages that the bot supports.
        public bool SplitEndpoints { get; set; }//Determines if the endpoints should be split by language.
        public TextFormat TextFormat { get; set; } //CSS styles
        public bool DisplaySelectionText { get; set; }//Set to false to hide the Make a Selection text for all nodes in the menu. Default is true.
        public bool DisplayChosenText { get; set; }//Set to false to hide the You Have Chosen text for all nodes in the menu. Default is true.
        public Queue DefaultQueue { get; set; } //Default queue to connect to if the user requests to bypass the menu.
        public List<string> BypassKeywords { get; set; }//List of keywords the user can type to bypass the menu.
        public bool AllowMenuBypass { get; set; }//Determines if the user is allowed to bypass the menu.Default is false.
        public bool DisplayMenuBypassMessage { get; set; } //Determines if the user is instructed on how to bypass the menu. Uses footer area. Default is false.

    }

    public class TextFormat
    {
        public string Header{ get; set; }//CSS styles for menu header text.
        public string Body{ get; set; }//CSS styles for regular text, such as "you have chosen" and instructional text, including footer text.
        public string Disclaimer { get; set; }//CSS styles for the disclaimer text.
        public string MenuOption { get; set; }//CSS styles for menu item text.
        public string MenuNumber { get; set; }//CSS styles for menu item number text.
        public string Error { get; set; }//CSS styles for error messages.
        public string GoBack { get; set; }//CSS styles for the "go back to the previous menu" system text.
    }

  public abstract class VirtualAgent : BotProfile
    {
        public string ApiBaseURL { get; set; }//URL for API calls.
        public bool ProactiveCallManagerActive { get; set; }//Determines if the proactive call manager should be started.
        public int ProactiveCallInterval { get; set; }//Time in seconds between polling requests. Default is 5.
        public string ProactiveCallAlias { get; set; }//Alias to place outbound calls with. (optional)
    }

    public class WatsonVirtualAgent : VirtualAgent
    {
        public List<string> SecurityHeaders { get; set; }//Headers for id and secret for API security.
    }
    public class MicrosoftVirtualAgent : VirtualAgent
    {
        public List<string> SupportedLanguages { get; set; }//List of languages that the bot supports.
        public bool LanguageAutoDetect { get; set; } //Determines if the bot will attempt to automatically detect the user's language by leveraging a CWE.
        public string CweGuid { get; set; }//Guid for a CWE visual component.
        public bool CweAutoStart { get; set; }//Determines if the CWE will open automatically when the conversation starts. Default is true. Only applies when a CweGuid is provided. Is always true if LanguageAutoDetect is true.

    }
}
