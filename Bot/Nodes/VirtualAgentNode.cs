using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bot.COMM;

namespace Bot.Core
{
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
}
