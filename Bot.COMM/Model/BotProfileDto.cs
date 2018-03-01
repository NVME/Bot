using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bot.COMM
{
    /// <summary>
    /// A DTO object contains all properties from all three bot profile types
    /// </summary>
    [DataContract]
    public class BotProfileDto : Dto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; } //Descriptive name for the bot. Internal use only.
        [DataMember]
        public List<BotEndpoint> BotSIP { get; set; }//List of Application Endpoints to register as bots. There will only be multiple items if the SplitEndpoints attribute is set to true.
        [DataMember]
        public int InactivityTimeout { get; set; } //Overrides the default conversation timeout with  a new timeout. Value is in minutes. (optional) Default is 20 minutes. Use 0 for no override.
        [DataMember]
        public int MobileInactivityTimeout { get; set; }//Overrides the default conversation timeout on mobile clients with  a new timeout. Value is in minutes. (optional) Default is 20 minutes. Use 0 for no override.
        [DataMember]
        public string CustomerId { get; set; }//The customer who owns the bot.
        [DataMember]
        public Language DefaultLanguage { get; set; }//Default language for system messages prior to language selection.
        [DataMember]
        public SystemTextSetting SystemTextSettings { get; set; }//Overrides some or all of the default system messages with custom text.
        [DataMember]
        public AgentSystemTextSetting AgentSystemTextSettings { get; set; }//Overrides some or all of the system messages from the service desk with custom text.
        [DataMember]
        public int InteractionFlowNodeId { get; set; } //Root node for the interaction flow tree.
        [DataMember]
        public FormattingOptions TextFormat { get; set; }//Text formatting options for this bot. Defines formatting for text that does not originate from a service or agent chat module.
        [DataMember]
        public List<Language> SupportedLanguages { get; set; } //List of languages that the bot supports.
        [DataMember]
        public bool SplitEndpoints { get; set; }//Determines if the endpoints should be split by language.
        [DataMember]
        public bool AllowMenuBypass { get; set; }//Determines if the user is allowed to bypass the menu. Default is false.
        [DataMember]
        public List<DefaultQueueDto> DefaultQueueIds { get; set; } //Default queue to connect to if the user requests to bypass the menu.
        [DataMember]
        public List<GlobalPhrase> BypassKeywords { get; set; }//List of keywords the user can type to bypass the menu.
        [DataMember]
        public bool DisplayMenuBypassMessage { get; set; }//Determines if the user is instructed on how to bypass the menu. Uses footer area. Default is false.
        [DataMember]
        public GlobalPhrase GlobalDisclaimer { get; set; } //A disclaimer message that will be displayed on all nodes (that support a disclaimer). Can override at the node level.
    }

    [DataContract]
    public class DefaultQueueDto
    {
        [DataMember]
        public QueueDto Queue { get; set; }
        [DataMember]
        public string LanguageCode { get; set; }
        [DataMember]
        public int LanguageId { get; set; }
    }
    [DataContract]
    public class BotEndpoint
    {
        [DataMember]
        public string SIP { get; set; }
        [DataMember]
        public string LanguageCode { get; set; }
        [DataMember]
        public int LanguageId { get; set; }
    }
}
