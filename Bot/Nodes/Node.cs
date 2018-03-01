
using System;
using System.Collections.Generic;
using Bot.COMM;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Core
{
    public abstract class Node:INode
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public Node Parent { get; set; }
        public FormattingOptions TextFormat { get; set; }
        public GlobalPhrase OptionDisplayText { get; set; }
        public List<GlobalPhrase> Keywords { get; set; }
        public string LanguageCode { get; set; }
        public string CweCommand { get; set; }
        public string AdditionalOptions { get; set; }
        protected Node()
        {
            LanguageCode = "en-us";// default language, will be reset in language node and pass to next node;
            Keywords = new List<GlobalPhrase>();
        }
        public virtual string GetOptionDisplayText(string languageCode)
        {
            return OptionDisplayText.Phrases.Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault();
        }
        public abstract string Display(SystemTextSetting settings);
        public abstract InteractionResult Handle(string userInput);
    }

   public class InteractionResult
    {
        public Node Next { get; set; }
        public string Message { get; set; }
    }
}
