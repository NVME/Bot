using System;
using System.Collections.Generic;
using Bot.COMM;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bot.Core
{
    public class MenuNode : Node, INode
    {
        public MenuNode() : base()
        {
            Nodes = new List<Node>();
        }
        public Header Header { get; set; }
        public Disclaimer Disclaimer { get; set; }
        public Footer Footer { get; set; }
        public List<Node> Nodes { get; set; }        
        public bool DisplayChosenText { get; set; }
        public bool DisplaySelectionText { get; set; }
        public bool DisableGoBackOption { get; set; }
        public bool HideMenu { get; set; }
        public bool HideMenuNumbers { get; set; }

        
        public override string Display()
        {
            return new XElement("div",
                    Header == null || Header.Text == null || Header.Text.Phrases.Count == 0 ?  // Header section
                    new XElement("foo") :// if header is empty, display <foo/>
                    new XElement("div",
                        new XElement("span",
                          new XElement("span", new XAttribute("style", Header.Format),
                            Header.Text.Phrases.Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault()
                            )
                      ),
                          new XElement("br"),
                          new XElement("br")
                      ),
                     Disclaimer == null || Disclaimer.Text == null || Disclaimer.Text.Phrases.Count == 0 ?  // Disclaimer section
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
                     Nodes == null ||Nodes.Count==0?// options section
                     new XElement("foo") :  //If options is empty, display < foo />
                     new XElement("div",
                            Nodes.Select((o, i) =>
                                    new XElement("span", new XAttribute("style", "color:#0000EE;"),
                                                 new XText((i + 1).ToString() + "."),
                                                 new XElement("span",o.OptionDisplay.Text.Phrases.Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault()),
                                                 new XElement("br")
                                                )
                                       ),
                             new XElement("br")
                            ),
                     Footer == null || Footer.Text == null || Footer.Text.Phrases.Count == 0 ?// Footer section
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
            throw   new NotImplementedException();
        }
    }

    
}
