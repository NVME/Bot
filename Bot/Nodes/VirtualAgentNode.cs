using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bot.COMM;
using Microsoft.Rtc.Collaboration;

namespace Bot.Core
{
    public class VirtualAgentNode : Node,INode
    {
        public VirtualAgentNode() : base() { }
        public GlobalPhrase HeaderText { get; set; }
        public GlobalPhrase DisclaimerText { get; set; }        
        public Queue Queue { get; set; }
        public bool ShowConfirmation { get; set; }
        public bool DisplayHoursOfOperation { get; set; }

       

        public override InteractionResult Handle(string userInput, BotSettingMini settings)
        {
            throw new NotImplementedException();
        }

        protected override string GetHtmlText(BotSettingMini settings)
        {
            throw new NotImplementedException();
        }

        protected override string GetPlainText(BotSettingMini settings)
        {
            throw new NotImplementedException();
        }
    }
}
