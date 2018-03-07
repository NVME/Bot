using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bot.COMM
{

    /// <summary>
    ///  A DTO object to have all feilds from all node types.
    /// </summary>
    [DataContract]
    public class NodeDto : Dto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ParentId { get; set; }
        [DataMember]
        public FormattingOptions TextFormat { get; set; }
        [DataMember]
        public GlobalPhrase HeaderText { get; set; }//Text displayed at the top of the menu. (optional)
        //[DataMember]
        //public string HeaderTextFormat { get; set; }//CSS formatting string for the text. (optional)
        [DataMember]
        public GlobalPhrase DisclaimerText { get; set; }//Text displayed in smaller font under the header. (optional)
        //[DataMember]
        //public string DisclaimerTextFormat { get; set; }//CSS formatting string for the text. (optional)
        [DataMember]
        public GlobalPhrase FooterText { get; set; }//Text displayed below the menu. (optional)
        //[DataMember]
        //public string FooterTextFormat { get; set; }//CSS formatting string for the text. (optional)
        [DataMember]
        public List<GlobalPhrase> Keywords { get; set; }//Keywords that will select this node from a menu. (optional)
        [DataMember]
        public GlobalPhrase OptionText { get; set; }//The text displayed in a menu containing this node.

        [DataMember]
        public GlobalPhrase InformationalText { get; set; }
        //[DataMember]
        //public string OptionTextFormat { get; set; }//CSS formatting string for the text. (optional)
        //[DataMember]
        //public bool DisplayChosenText { get; set; }//Determines if the standard "You have chosen the xxx option" text is shown. Default is true.
        //[DataMember]
        //public bool DisplaySelectionText { get; set; }//Determines if the selection instruction text is displayed. Default is true.
        [DataMember]
        public bool DisableGoBackOption { get; set; }//Determines if the standard "Go back to the previous level" option is shown (if applicable). Default is false.
        [DataMember]
        public bool DisplayConnectionText { get; set; }//Determines if the standard connecting message is displayed. Default is true.
        [DataMember]
        public bool HideMenu { get; set; }//Determines if the menu options are shown. Default is false.
        [DataMember]
        public bool HideMenuNumbers { get; set; }//Determines if numbers appear before menu options. Default is false.
        [DataMember]
        public string CweCommand { get; set; }//Data to send to a CWE if present. (optional)
        [DataMember]
        public string AdditionalOptions { get; set; }//For additional options from future enhancements.
        [DataMember]
        public QueueDto Queue { get; set; }//The queue to connect to.
        [DataMember]
        public GlobalQueueName QueueName { get; set; }//The name of the queue to be connected to.
        [DataMember]
        public bool ShowConfirmation { get; set; }//Determines if a confirmation screen is shown before connecting. Default is true.
        [DataMember]
        public bool DisplayHoursOfOperation { get; set; }//Determines if the queue's hours of operation are added to the OptionText. Default is false.
        [DataMember]
        public List<LanguageOptionDto> LanguageOptions { get; set; }//List of languages. Might be taken from bot setup. Might be the place to specify the bot's languages.
        
        [DataMember]
        public bool UseEnglishLanguageName { get; set; }//Displays the English name for each language in the menu instead of the localized name.
        [DataMember]
        public int NodeLinkNodeId { get; set; } // used by node link
    }

    [DataContract]
    public class InformationalNodeDto : NodeDto
    {
        public InformationalNodeDto()
        {
            DisclaimerText = null;
           // DisclaimerTextFormat = "";
            FooterText = null;
           // FooterTextFormat = "";
            LanguageOptions = null;           
            Queue = null;
            QueueName = null;
            UseEnglishLanguageName = false;
            DisableGoBackOption = true;
            //DisplayChosenText = true;
            DisplayHoursOfOperation = false;
           // DisplaySelectionText = false;
            ShowConfirmation = false;
            HideMenu = false;
            HideMenuNumbers = false;
            AdditionalOptions = "";
            CweCommand = "";
        }

    }
}
