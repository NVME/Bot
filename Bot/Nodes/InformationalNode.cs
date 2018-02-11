using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bot.COMM;

namespace Bot.Core
{
    public class InformationalNode : Node
    {
        public Header Header { get; set; }
        public OptionDisplay OptionDisplay { get; set; }
        public bool DisplayChosenText { get; set; }
        public bool DisplayConnectionText { get; set; }
        public bool DisableGoBackOption { get; set; }
        public InformationalNode() : base() { }
    }
}
