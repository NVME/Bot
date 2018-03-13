using System;
using System.Collections.Generic;
using Bot.COMM;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Core
{
    public class BotProfile : Setting
    {
        public int Id { get; set; }
        public string Name { get; set; }//Descriptive name for the bot. Internal use only.
        public List<BotEndpoint> BotSIP { get; set; }//List of Application Endpoints to register as bots. There will only be multiple items if the SplitEndpoints attribute is set to true.
        public string CustomerId { get; set; }//The customer who owns the bot.
        public string DefaultLanguage { get; set; }//Default language for system messages prior to language selection.       
        public Node InteractionFlowNode { get; set; } //Root node for the interaction flow tree.      
        public List<Language> SupportedLanguages { get; set; } //List of languages that the bot supports.       
        public bool SplitEndpoints { get; set; }//Determines if the endpoints should be split by language.  
        public List<DefaultQueueDto> DefaultQueueIds { get; set; } //Default queue to connect to if the user requests to bypass the menu.        
        public MenuBypassSetting MenuBypassSetting { get; set; }
        public BotSettingMini MinifySettings() // used by menu dispaly, If need override by top level setting, do it here and leave original bot setting as it was.
        {
            return new BotSettingMini
            {
                SystemTexts = this.SystemTextSettings,
                MenuBypass = this.MenuBypassSetting,
                AgentSystemTexts = this.AgentSystemTextSettings
            };
        }
    }

    public class MenuBypassSetting
    {
        public bool AllowMenuBypass { get; set; }//Determines if the user is allowed to bypass the menu. Default is false.  
        public List<GlobalPhrase> BypassKeywords { get; set; }//List of keywords the user can type to bypass the menu.        
        public bool DisplayMenuBypassMessage { get; set; }//Determines if the user is instructed on how to bypass the menu. Uses footer area. Default is false.       
    }

    public class BotSettingMini
    {
        public MenuBypassSetting MenuBypass { get; set; }
        public SystemTextSetting SystemTexts { get; set; }
        public AgentSystemTextSetting AgentSystemTexts{ get; set; }
    }
    public class DefaultQueue
    {
        public Queue Queue { get; set; }
        public string LanguageCode { get; set; }
        public int LanguageId { get; set; }
    }

}
