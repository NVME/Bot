using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bot.COMM
{

    /// <summary>
    /// Formatting Options : Default, Customer, Bot and Node , total 4 levels, only use the deeper level setting, eg: if setting from Node is empty, then use Bot level setting..
    /// To make simple use of those 4 levels setting , when create node object ,will validate all node settings , if empty, then replace it with nearest avaliable one.so we can always get the setting value unless the default one is empty.
    /// TBD: Might have this replacement done on config manger side, then there will no need to pass the default settings and customer to Bot....
    /// Same to SystemTextSettings and  AgentSystemTextSettings but they only have 3 levels :Default, Customer, Bot.
    /// </summary>
    [DataContract]
    public abstract class Setting
    {
        [DataMember]
        public FormattingOptions TextFormat { get; set; }//Default text formatting options
        [DataMember]
        public int InactivityTimeout { get; set; }//Overrides the default conversation timeout with  a new timeout. Value is in minutes. (optional) Default is 20 minutes. Use 0 for no override.
        [DataMember]
        public int MobileInactivityTimeout { get; set; }//Overrides the default conversation timeout on mobile clients with  a new timeout. Value is in minutes. (optional) Default is 20 minutes. Use 0 for no override.
        [DataMember]
        public SystemTextSetting SystemTextSettings { get; set; }//Default system messages with custom text.
        [DataMember]
        public AgentSystemTextSetting AgentSystemTextSettings { get; set; }//System messages from the service desk with custom text.

    }

    [DataContract]
    public class DefaultSetting : Setting { }//Used if no custom per customer, per bot, or per node settings are supplied.
    [DataContract]
    public class AgentSystemTextSetting
    {
        [DataMember]
        public List<AgentSystemPhrase> Phrases { get; set; }
    }
    [DataContract]
    public class AgentSystemPhrase
    {
        private GlobalPhrase replaceSetting;
        
        public AgentSystemPhrase()
        {
            Skip = false;
            AutoReply = false;
        }
        [DataMember]
        public int Id { get; set; }//An identifier for the phrase, for internal purposes.
        [DataMember]
        public string MatchString { get; set; }//A string to match messages from AIC against. May need to be able to match against strings with variable numbers like "You have been inactive for 5 minutes".
        [DataMember]
        public GlobalPhrase ReplaceString
        {// Multi-lingual string to replace the AIC message with.Not used if Skip or AutoReply are set to true.
            get { return Skip || AutoReply ? new GlobalPhrase() : replaceSetting; } // return empty phrase if skip or auto reply is true.
            set { replaceSetting = value; }
        }
        [DataMember]
        public bool Skip { get; set; }//If true, does not forward the message to the user. Default is false.
        [DataMember]
        public bool AutoReply { get; set; }//If true, sends and automatic reply to the XMPP system. Used in response to timeout warnings to keep conversations alive. Default is false.

    }
    [DataContract]
    public class TextSetting
    {
        [DataMember]
        public GlobalPhrase Content { get; set; }
        [DataMember]
        public string DisplayName { get; set; }
    }
    [DataContract]
    public class SystemTextSetting
    {
        [DataMember]
        public TextSetting ChosenText { get; set; }//Message displayed to the user to confirm their selection. Ex. "You have chosen Password Reset."
        [DataMember]
        public TextSetting SelectionText { get; set; }//Message instructing the user to make a selection. Ex. "Please enter a number to make a selection."
        [DataMember]
        public TextSetting SelectionError { get; set; }//Message alerting the user that their selection was invalid.
        [DataMember]
        public TextSetting AgentConnectingText { get; set; }//Message informing the user that a connection to an agent is being opened.
        [DataMember]
        public TextSetting MessageFailureText { get; set; }//Message informing the user that an error occurred while sending their message.
        [DataMember]
        public TextSetting GeneralErrorText { get; set; }//Message informing the user that an error occurred with the service. Should be generic, and represent any error which would prevent the user from continuing.
        [DataMember]
        public TextSetting AgentConnectionFailureText { get; set; }//Message informing the user that an error occurred while attempting to connect to a service desk.
        [DataMember]
        public TextSetting AgentNotAvailableText { get; set; }//Message informing the user that no agents were available at the requested service desk.
        [DataMember]
        public TextSetting AgentClosedText { get; set; }//Message informing the user that the desk is not open at this time.
        [DataMember]
        public TextSetting AgentConnectionClosedText { get; set; }//Message informing the user that the conversation with the service desk has terminated. Used at the time of connection termination.
        [DataMember]
        public TextSetting AgentConnectionCompletedText { get; set; }//Message informing the user that the conversation with the service desk has terminated. Used when the user sends a message after termination.
        [DataMember]
        public TextSetting ServiceCompletedText { get; set; }//Message informing the user that they should close the conversation and call again.
        [DataMember]
        public TextSetting MaintenanceWindowWarningText { get; set; }//Message warning the user that the system will be shutting down for maintenance in x minutes.
        [DataMember]
        public TextSetting MaintenanceWindowInfoText { get; set; }//Message informing the user that the system is temporarily down for maintenance.
        [DataMember]
        public TextSetting ServiceStartFailureText { get; set; }//Message informing the user that the service (VA API for example) is not available or a session could not be started.
        [DataMember]
        public TextSetting LanguageSelectionText { get; set; }//Message instructing the user to select a language.
        [DataMember]
        public TextSetting HandoffConfirmationText { get; set; }//Message used to verify that a user wants to be connected to a live agent.
        [DataMember]
        public TextSetting GoBackText { get; set; }//Message instructing a user how go backward in the tree.
        [DataMember]
        public TextSetting AgentBypassText { get; set; }//Message instructing a user how to bypass the menu and speak directly with an agent.
        [DataMember]
        public string PreviousMenuLevelCharacter { get; set; } //Symbol used in a menu to allow the user to go back a level. The default should be "#".

    }
}
