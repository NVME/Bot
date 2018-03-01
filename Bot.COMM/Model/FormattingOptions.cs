using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bot.COMM
{
    [DataContract]
    public class FormattingOptions
    {
        [DataMember]
        public string HeaderTextFormat { get; set; } // CSS styles for menu header text.
        [DataMember]
        public string BodyTextFormat { get; set; }  //CSS styles for regular text, such as "you have chosen" and instructional text, including footer text.
        [DataMember]
        public string DisclaimerTextFormat { get; set; } //CSS styles for the disclaimer text.
        [DataMember]
        public string MenuOptionTextFormat { get; set; } //CSS styles for menu item text.
        [DataMember]
        public string MenuNumberTextFormat { get; set; } //CSS styles for menu item number text.
        [DataMember]
        public string ErrorTextFormat { get; set; } //CSS styles for error messages.
        [DataMember]
        public string GoBackTextFormat { get; set; }//CSS styles for the "go back to the previous menu" system text.
        [DataMember]
        public bool DisplaySelectionText { get; set; }//Set to false to hide the Make a Selection text for all nodes in the menu. Default is true.
        [DataMember]
        public bool DisplayChosenText { get; set; }//Set to false to hide the You Have Chosen text for all nodes in the menu. Default is true.

    }
}
