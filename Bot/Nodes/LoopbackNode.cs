using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bot.COMM;

namespace Bot.Core
{
    public class LoopbackNode : Node
    {
        public LoopbackNode() : base() { }
        public OptionDisplay Option { get; set; }

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
