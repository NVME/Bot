using System;
using System.Collections.Generic;
using Bot.COMM;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Core
{
    public class LanguageNode : Node, INode
    {
        public Header Header { get; set; }
        public Disclaimer Disclaimer { get; set; }
        public Footer Footer { get; set; }
        public List<LanguageOption> LanguageOptions { get; set; }
        public List<string> LanguagesAltText { get; set; }
        public bool UseEnglishLanguageName { get; set; }
        public LanguageNode() : base()
        {
            LanguageOptions = new List<LanguageOption>();
            LanguagesAltText = new List<string>();
        }

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
