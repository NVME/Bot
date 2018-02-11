using System;
using System.Collections.Generic;
using Bot.COMM;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Core
{
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
}
