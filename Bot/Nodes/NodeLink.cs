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

        public override DisplayResult Display(SystemTextSetting settings)
        {
            return new DisplayResult { Message = null, Type = DisplayResultType.NodeLinkNoDisplay };
        }
        public override InteractionResult Handle(string userInput, SystemTextSetting settings)
        {
            if (!Goto.IsLanguageNode) Goto.LanguageCode = this.LanguageCode;
            return new InteractionResult { Next = Goto, Type = InteractionResultType.JumpTo };
        }
        protected override string GetHtmlText(SystemTextSetting settings)
        {
            throw new NotImplementedException();
        }

        protected override string GetPlainText(SystemTextSetting settings)
        {
            throw new NotImplementedException();
        }
    }
}
