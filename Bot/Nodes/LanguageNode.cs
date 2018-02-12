using System;
using System.Collections.Generic;
using Bot.COMM;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            return new XElement("div",
                    Header == null || Header.Text == null || Header.Text.Phrases.Count==0 ?  // Header section
                    new XElement("foo") :// if header is empty, display <foo/>
                    new XElement("div",
                        new XElement("span",
                          new XElement("span", new XAttribute("style", Header.Format),
                            Header.Text.Phrases.Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p=>p.Text).FirstOrDefault()
                            )
                      ),
                          new XElement("br"),
                          new XElement("br")
                      ),
                     Disclaimer == null|| Disclaimer.Text==null|| Disclaimer.Text.Phrases.Count==0 ?  // Disclaimer section
                     new XElement("foo") :  //if Disclaimer is empty, display < foo />
                     new XElement("div",
                         new XElement("span",
                            new XElement("span", new XAttribute("style", Disclaimer.Format),
                                Disclaimer.Text.Phrases.Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault()
                                )
                          ),
                          new XElement("br"),
                          new XElement("br")
                      ),
                     LanguageOptions == null ?// options section
                     new XElement("foo") :  //If options is empty, display < foo />
                     new XElement("div",
                            LanguageOptions.Select((l,i) =>
                                    new XElement("span", new XAttribute("style", "color:#0000EE;"),
                                                 new XText((i+1).ToString()+"."),
                                                 new XElement("span", UseEnglishLanguageName ? l.Language.EnglishName : l.Language.LocalName),
                                                 new XElement("br")
                                                )
                                       ),
                             new XElement("br")
                            ),
                     Footer == null || Footer.Text == null || Footer.Text.Phrases.Count== 0 ?// Footer section
                     new XElement("foo") :  //If fotter is empty, display < foo />
                      new XElement("div",
                        new XElement("span",
                          new XElement("span", new XAttribute("style", Footer.Format),
                            Footer.Text.Phrases.Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault()
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
