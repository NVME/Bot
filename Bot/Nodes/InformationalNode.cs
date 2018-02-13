using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bot.COMM;
using System.Xml.Linq;

namespace Bot.Core
{
    public class InformationalNode : Node, INode
    {
        public Header Header { get; set; }        
        public bool DisplayChosenText { get; set; }
        public bool DisplayConnectionText { get; set; }
        public bool DisableGoBackOption { get; set; }
        public InformationalNode() : base() { }

        public override string Display()
        {
            return new XElement("div",
                    Header == null || Header.Text == null || Header.Text.Phrases.Count == 0 ?  // Header section
                    new XElement("foo") :// if header is empty, display <foo/>
                    new XElement("div",
                        new XElement("span", new XAttribute("style", string.IsNullOrEmpty(Header.Format) ?
                                                                     DefaultSettingSingleton.Instance.HeaderTextFormat : Header.Format),
                          new XElement("span",
                            Header.Text.Phrases.Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault()
                            )
                      ),
                          new XElement("br"),
                          new XElement("br")
                      ),
                    
                      !DisplayChosenText ?//if display chosen text is false, display < foo />
                      new XElement("foo") :
                      new XElement("div",  // display chose text ,Ex. "You have chosen Password Reset."
                          new XElement("span", new XAttribute("style", DefaultSettingSingleton.Instance.BodyTextFormat),
                                    new XElement("span",
                                       DefaultSettingSingleton.Instance.SystemTextSettings.ChosenText.Content.Phrases
                                                .Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault().TrimEnd()
                                        + " " +
                                        OptionDisplay.Text.Phrases
                                                .Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault().TrimEnd()
                                        )
                          ),
                          new XElement("br"),
                          new XElement("br")
                     ),
                    
                      !DisableGoBackOption ?//if display go back text is false, display < foo />
                      new XElement("foo") :
                      new XElement("div",
                          new XElement("span", new XAttribute("style", DefaultSettingSingleton.Instance.BodyTextFormat),
                                    new XElement("span",
                                       DefaultSettingSingleton.Instance.SystemTextSettings.GoBackText.Content.Phrases
                                                .Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault()
                                        )
                          )
                     )
                ).ToString().Replace("<foo />", string.Empty);
        }

        public override KeyValuePair<Node, string> Handle(string userInput)
        {
            throw new NotImplementedException();
        }
    }
}
