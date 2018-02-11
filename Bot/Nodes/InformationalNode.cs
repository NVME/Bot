using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bot.COMM;

namespace Bot.Core
{
    public class InformationalNode : Node, INode
    {
        public Header Header { get; set; }
        public OptionDisplay OptionDisplay { get; set; }
        public bool DisplayChosenText { get; set; }
        public bool DisplayConnectionText { get; set; }
        public bool DisableGoBackOption { get; set; }
        public InformationalNode() : base() { }

        public override string Display()
        {
            throw new NotImplementedException();
        }

        public override KeyValuePair<Node, string> Handle(string userInput)
        {
            throw new NotImplementedException();
        }
    }
}
