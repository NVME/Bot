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
        public GlobalPhrase HeaderText { get; set; }
        public GlobalPhrase DisclaimerText { get; set; }
        public GlobalPhrase FooterText { get; set; }
        public List<Node> Nodes { get; set; }       
        public bool DisableGoBackOption { get; set; }
        public bool HideMenu { get; set; }
        public bool HideMenuNumbers { get; set; }


        public override string Display(SystemTextSetting settings)
        {
            return new XElement("div",
                     HeaderText == null || HeaderText.Phrases.Count == 0 ?  // Header section
                    new XElement("foo") :// if header is empty, display <foo/>
                    new XElement("div",
                        new XElement("span", new XAttribute("style", TextFormat.HeaderTextFormat),
                          new XElement("span",
                            HeaderText.Phrases.Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault()
                            )
                      ),
                          new XElement("br"),
                          new XElement("br")
                      ),
                     DisclaimerText == null || DisclaimerText.Phrases.Count == 0 ?  // Disclaimer section
                     new XElement("foo") :  //if Disclaimer is empty, display < foo />
                     new XElement("div",
                         new XElement("span", new XAttribute("style", TextFormat.DisclaimerTextFormat),
                            new XElement("span",
                                DisclaimerText.Phrases.Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault()                                
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
                     !TextFormat.DisplaySelectionText ?//if display selection text is false, display < foo />
                      new XElement("foo") :
                      new XElement("div",
                          new XElement("span", new XAttribute("style", TextFormat.BodyTextFormat),
                                    new XElement("span",
                                      settings.SelectionText.Content.Phrases
                                                .Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault()
                                        )
                          ),
                          new XElement("br"),
                          new XElement("br")
                     ),

                     Nodes == null || Nodes.Count == 0 || HideMenu ?// options section
                     new XElement("foo") :  //If options is empty, display < foo />
                     new XElement("div",
                            Nodes.Select((o, i) =>
                               new XElement("div",
                                    new XElement("span", new XAttribute("style", o.TextFormat.MenuNumberTextFormat),
                                            new XText(HideMenuNumbers ? "" : (i + 1).ToString() + ".")
                                            ),
                                    new XElement("span", new XAttribute("style", o.TextFormat.MenuOptionTextFormat),
                                                        new XElement("span", o.GetOptionDisplayText(this.LanguageCode))
                                                 ),
                                         new XElement("br")
                                       )),
                             new XElement("br")
                            ),
                      !DisableGoBackOption ?//if display go back text is false, display < foo />
                      new XElement("foo") :
                      new XElement("div",
                          new XElement("span", new XAttribute("style",TextFormat.GoBackTextFormat),
                                    new XElement("span",
                                      settings.GoBackText.Content.Phrases
                                                .Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault()
                                        )
                          ),
                          new XElement("br"),
                          new XElement("br")
                     ),
                    FooterText == null || FooterText.Phrases.Count == 0 ?// Footer section
                     new XElement("foo") :  //If fotter is empty, display < foo />
                      new XElement("div",
                        new XElement("span", new XAttribute("style", TextFormat.BodyTextFormat),
                          new XElement("span",
                            FooterText.Phrases.Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault()
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
