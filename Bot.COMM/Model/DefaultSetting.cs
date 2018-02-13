using System;
using System.Collections.Generic;


namespace Bot.COMM
{
    public class DefaultSetting
    {
        
        public string HeaderTextFormat { get; set; }//CSS styles for menu header text.
        public string BodyTextFormat { get; set; }//CSS styles for regular text, such as "you have chosen" and instructional text, including footer text.
        public string DisclaimerTextFormat { get; set; }//CSS styles for the disclaimer text.
        public string MenuOptionTextFormat { get; set; }//CSS styles for menu item text.
        public string MenuNumberTextFormat { get; set; }//CSS styles for menu item number text.
        public string ErrorTextFormat { get; set; }//CSS styles for error messages.
        public string GoBackTextFormat { get; set; }//CSS styles for the "go back to the previous menu" system text.
        public int InactivityTimeout { get; set; }//Overrides the default conversation timeout with  a new timeout. Value is in minutes. (optional) Default is 20 minutes. Use 0 for no override.
        public int MobileInactivityTimeout { get; set; }//Overrides the default conversation timeout on mobile clients with  a new timeout. Value is in minutes. (optional) Default is 20 minutes. Use 0 for no override.
        public SystemTextSetting SystemTextSettings { get; set; }//Default system messages with custom text.
        public AgentSystemTextSetting AgentSystemTextSettings { get; set; }//System messages from the service desk with custom text.

    }

    public class AgentSystemTextSetting
    {
        public List<AgentSystemPhrase> Phrases { get; set; }
    }

    public class AgentSystemPhrase
    {
        private GlobalPhrase replaceSetting;
        public AgentSystemPhrase()
        {
            Skip = false;
            AutoReply = false;
        }
        public int Id { get; set; }//An identifier for the phrase, for internal purposes.
        public string MatchString { get; set; }//A string to match messages from AIC against. May need to be able to match against strings with variable numbers like "You have been inactive for 5 minutes".
        public GlobalPhrase ReplaceString
        {// Multi-lingual string to replace the AIC message with.Not used if Skip or AutoReply are set to true.
            get { return Skip || AutoReply ? new GlobalPhrase() : replaceSetting; } // return empty phrase if skip or auto reply is true.
            set { replaceSetting = value; }
        }
        public bool Skip { get; set; }//If true, does not forward the message to the user. Default is false.
        public bool AutoReply { get; set; }//If true, sends and automatic reply to the XMPP system. Used in response to timeout warnings to keep conversations alive. Default is false.

    }

    public class TextSetting
    {
        public GlobalPhrase Content { get; set; }
        public string DisplayName { get; set; }
    }

    public class SystemTextSetting
    {
        public TextSetting ChosenText { get; set; }//Message displayed to the user to confirm their selection. Ex. "You have chosen Password Reset."
        public TextSetting SelectionText { get; set; }//Message instructing the user to make a selection. Ex. "Please enter a number to make a selection."
        public TextSetting SelectionError { get; set; }//Message alerting the user that their selection was invalid.
        public TextSetting AgentConnectingText { get; set; }//Message informing the user that a connection to an agent is being opened.
        public TextSetting MessageFailureText { get; set; }//Message informing the user that an error occurred while sending their message.
        public TextSetting GeneralErrorText { get; set; }//Message informing the user that an error occurred with the service. Should be generic, and represent any error which would prevent the user from continuing.
        public TextSetting AgentConnectionFailureText { get; set; }//Message informing the user that an error occurred while attempting to connect to a service desk.
        public TextSetting AgentNotAvailableText { get; set; }//Message informing the user that no agents were available at the requested service desk.
        public TextSetting AgentClosedText { get; set; }//Message informing the user that the desk is not open at this time.
        public TextSetting AgentConnectionClosedText { get; set; }//Message informing the user that the conversation with the service desk has terminated. Used at the time of connection termination.
        public TextSetting AgentConnectionCompletedText { get; set; }//Message informing the user that the conversation with the service desk has terminated. Used when the user sends a message after termination.
        public TextSetting ServiceCompletedText { get; set; }//Message informing the user that they should close the conversation and call again.
        public TextSetting MaintenanceWindowWarningText { get; set; }//Message warning the user that the system will be shutting down for maintenance in x minutes.
        public TextSetting MaintenanceWindowInfoText { get; set; }//Message informing the user that the system is temporarily down for maintenance.
        public TextSetting ServiceStartFailureText { get; set; }//Message informing the user that the service (VA API for example) is not available or a session could not be started.
        public TextSetting LanguageSelectionText { get; set; }//Message instructing the user to select a language.
        public TextSetting HandoffConfirmationText { get; set; }//Message used to verify that a user wants to be connected to a live agent.
        public TextSetting GoBackText { get; set; }//Message instructing a user how go backward in the tree.
        public TextSetting AgentBypassText { get; set; }//Message instructing a user how to bypass the menu and speak directly with an agent.


    }
}
