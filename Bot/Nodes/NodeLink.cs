using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bot.COMM;

namespace Bot.Core
{
    public class NodeLink : Node, INode
    {
        public NodeLink() : base() { }
        public int NodeLinkNodeId { get; set; }
        public Node Goto { get; set; }
        public override string Display(SystemTextSetting settings)
        {
            throw new NotImplementedException(" No display for this type of node");
        }

        public override InteractionResult Handle(string userInput)
        {
            return new InteractionResult { Next = Goto };
        }
    }
}
