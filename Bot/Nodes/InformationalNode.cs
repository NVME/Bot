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
        public GlobalPhrase HeaderText { get; set; } 
        public bool DisplayConnectionText { get; set; }
        public bool DisableGoBackOption { get; set; }
        public InformationalNode() : base() { }

        public override string Display(SystemTextSetting settings)
        {
            return new XElement("div",
                     HeaderText == null || HeaderText.Phrases.Count == 0 ?  // Header section
                    new XElement("foo") :// if header is empty, display <foo/>
                    new XElement("div",
                        new XElement("span", new XAttribute("style",  TextFormat.HeaderTextFormat),
                          new XElement("span",
                            HeaderText.Phrases.Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault()
                            )
                      ),
                          new XElement("br"),
                          new XElement("br")
                      ),
                    
                      !TextFormat.DisplayChosenText ?//if display chosen text is false, display < foo />
                      new XElement("foo") :
                      new XElement("div",  // display chose text ,Ex. "You have chosen Password Reset."
                          new XElement("span", new XAttribute("style", TextFormat.BodyTextFormat),
                                    new XElement("span",
                                      settings.ChosenText.Content.Phrases
                                                .Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault().TrimEnd()
                                        + " " +
                                        OptionDisplayText.Phrases
                                                .Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault().TrimEnd()
                                        )
                          ),
                          new XElement("br"),
                          new XElement("br")
                     ),
                    
                      !DisableGoBackOption ?//if display go back text is false, display < foo />
                      new XElement("foo") :
                      new XElement("div",
                          new XElement("span", new XAttribute("style", TextFormat.GoBackTextFormat),
                                    new XElement("span",
                                      settings.GoBackText.Content.Phrases
                                                .Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault()
                                        )
                          )
                     )
                ).ToString().Replace("<foo />", string.Empty);
        }

        public override InteractionResult Handle(string userInput)
        {
            throw new NotImplementedException();
        }
    }
}
