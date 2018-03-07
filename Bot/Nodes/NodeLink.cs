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
        public int TargetNode { get; set; }
        public Node Goto { get; set; }
       

        public override InteractionResult Handle(string userInput, SystemTextSetting settings)
        {
            return new InteractionResult { Next = Goto, Type=ResultType.JumpTo };
        }

        public override string GetHtmlText(SystemTextSetting settings)
        {
            throw new NotImplementedException();
        }

        public override string GetPlainText(SystemTextSetting settings)
        {
            throw new NotImplementedException();
        }
    }
}
