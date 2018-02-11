using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bot.COMM;

namespace Bot.Core
{
    public class HandoffNode : Node
    {
        public HandoffNode() : base() { }
        public Header Header { get; set; }
        public Disclaimer Disclaimer { get; set; }
        public OptionDisplay OptionDisplay { get; set; }
        public Queue Queue { get; set; }
        public bool ShowConfirmation { get; set; }
        public bool DisplayHoursOfOperation { get; set; }

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
