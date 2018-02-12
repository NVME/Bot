
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
        public OptionDisplay OptionDisplay { get; set; }
        public List<GlobalPhrase> Keywords { get; set; }
        public string LanguageCode { get; set; }
        public string CweCommand { get; set; }
        public string AdditionalOptions { get; set; }
        protected Node()
        {
            LanguageCode = "en-us";// default language, will be reset in language node and pass to next node;
            Keywords = new List<GlobalPhrase>();
        }

        public abstract string Display();
        public abstract KeyValuePair<Node, string> Handle(string userInput);
    }

    #region Parts
    public class TextBase
    {
        public GlobalPhrase Text { get; set; }
        public string Format { get; set; }
    }
    public class Header : TextBase { }
    public class Disclaimer : TextBase { }
    public class Footer : TextBase { }
    public class OptionDisplay : TextBase { }



    #endregion
}
