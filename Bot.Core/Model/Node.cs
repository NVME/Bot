using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.COMM
{
    public abstract class Node
    {     
        public int Id { get; set; }
        public int ParentId { get; set; }
        public Node Parent { get; set; }
        public List<string> Keywords { get; set; }
        public string CweCommand { get; set; }
        public string AdditionalOptions { get; set; }
        protected Node()
        {
            Keywords = new List<string>();
        }
    }
    public class LanguageNode :Node
    {       
        public Header Header { get; set; }
        public Disclaimer Disclaimer { get; set; }
        public Footer Footer { get; set; }
        public List<LanguageOption> LanguageOptions { get; set; }
        public List<string> LanguagesAltText { get; set; }
        public bool UseEnglishLanguageName { get; set; }
        public LanguageNode() : base()
        {
            LanguageOptions = new List<LanguageOption>();
            LanguagesAltText = new List<string>();
        }
    }

    public class MenuNode : Node
    {
        public MenuNode() : base()
        {
            Nodes = new List<Node>();
        }
        public Header Header { get; set; }
        public Disclaimer Disclaimer { get; set; }
        public Footer Footer { get; set; }
        public List<Node> Nodes { get; set; }
        public OptionDisplay OptionDisplay { get; set; }
        public bool DisplayChosenText { get; set; }
        public bool DisplaySelectionText { get; set; }
        public bool DisableGoBackOption { get; set; }
        public bool HideMenu { get; set; }
        public bool HideMenuNumbers { get; set; } 
    }     
  
    public class InformationalNode:Node
    {     
        public Header Header { get; set; }
        public OptionDisplay OptionDisplay { get; set; }
        public bool DisplayChosenText { get; set; }        
        public bool DisplayConnectionText { get; set; }
        public bool DisableGoBackOption { get; set; }
        public InformationalNode() : base() { }
    }

    public class LoopbackNode : Node
    {
        public LoopbackNode() : base() { }
        public OptionDisplay Option { get; set; }
    }

    public class HandoffNode : Node
    {
        public HandoffNode() : base() { }       
        public Header Header { get; set; }
        public Disclaimer Disclaimer { get; set; }
        public OptionDisplay OptionDisplay { get; set; }
        public Queue Queue { get; set; }       
        public bool ShowConfirmation { get; set; }
        public bool DisplayHoursOfOperation { get; set; }
    }

    public class VirtualAgentNode : Node
    {
        public VirtualAgentNode() : base() { }
        public Header Header { get; set; }
        public Disclaimer Disclaimer { get; set; }
        public OptionDisplay OptionDisplay { get; set; }
        public Queue Queue { get; set; }        
        public bool ShowConfirmation { get; set; }
        public bool DisplayHoursOfOperation { get; set; }
    }

    #region Parts
    public class TextBase
    {
        public GlobalPhrase Text { get; set; }
        public string Format { get; set; }
    }
    public class Header : TextBase { }
    public class Disclaimer : TextBase { }
    public class Footer : TextBase { }
    public class OptionDisplay : TextBase { }

   

    #endregion


}
