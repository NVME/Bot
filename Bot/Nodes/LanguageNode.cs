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
        public GlobalPhrase HeaderText { get; set; }
        public GlobalPhrase DisclaimerText { get; set; }
        public GlobalPhrase FooterText { get; set; }
        public List<LanguageOption> LanguageOptions { get; set; }
        public List<string> LanguagesAltText { get; set; }
        public bool UseEnglishLanguageName { get; set; }
        public LanguageNode() : base()
        {
            LanguageOptions = new List<LanguageOption>();
            LanguagesAltText = new List<string>();
        }

        public override string GetHtmlText(SystemTextSetting settings)
        {
           
            var html = new XElement("div",
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
                     LanguageOptions == null ?// options section
                     new XElement("foo") :  //If options is empty, display < foo />
                     new XElement("div",
                            LanguageOptions.Select((l, i) =>
                               new XElement("div",
                                       new XElement("span", new XAttribute("style", TextFormat.MenuNumberTextFormat),
                                                         new XText((i + 1).ToString() + ".")
                                                    ),
                                       new XElement("span", new XAttribute("style", TextFormat.MenuOptionTextFormat),
                                                         new XElement("span", UseEnglishLanguageName ? l.Language.EnglishName : l.Language.LocalName)
                                                        )
                                               ,
                                     new XElement("br")
                                    )
                               ),
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
                );
            html.Descendants("foo").Remove();
            return html.ToString();
        }

        public override string GetPlainText(SystemTextSetting settings)
        {
            throw new NotImplementedException();
        }

        public override InteractionResult Handle(string userInput)
        {
            throw new NotImplementedException();
        }

    }
}
