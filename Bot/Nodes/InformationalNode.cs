using System;
using System.Collections.Generic;
using System.Linq;
using Bot.COMM;
using System.Xml.Linq;
using System.Text;

namespace Bot.Core
{
    public class InformationalNode : Node, INode
    {
        public GlobalPhrase HeaderText { get; set; }
        public GlobalPhrase DisclaimerText { get; set; }// can be override by GlobalDisclaimer, TBD: Deceide how /when to override , on configure manager side or bot .
        public GlobalPhrase InformationalText { get; set; }
        public GlobalPhrase FooterText { get; set; }
        public bool DisableGoBackOption { get; set; }
        public InformationalNode() : base() { }

        protected override string GetHtmlText(SystemTextSetting settings)
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
                      !TextFormat.DisplayChosenText ?//if display chosen text is false, display < foo />
                      new XElement("foo") :
                      new XElement("div",  // display chose text ,Ex. "You have chosen Password Reset."
                          new XElement("span", new XAttribute("style", TextFormat.BodyTextFormat),
                                    new XElement("span",
                                     string.Format(
                                         settings.ChosenText.Content.Phrases
                                                .Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault().TrimEnd()
                                       ,
                                        OptionDisplayText.Phrases
                                                .Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault().TrimEnd()
                                        )
                                     )
                          ),
                          new XElement("br"),
                          new XElement("br")
                     ),
                    InformationalText == null || InformationalText.Phrases.Count == 0 ?  // Header section
                    new XElement("foo") :// if header is empty, display <foo/>
                       new XElement("div",
                        new XElement("span", new XAttribute("style", TextFormat.BodyTextFormat),
                          new XElement("span",
                            InformationalText.Phrases.Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault()
                            )
                         ),
                         new XElement("br"),
                         new XElement("br")
                      ),

                      DisableGoBackOption ?//if display go back text is disabled, display < foo />
                      new XElement("foo") :
                      new XElement("div",
                           new XElement("span", new XText(settings.PreviousMenuLevelCharacter + ".")
                                                         ),
                          new XElement("span", new XAttribute("style", TextFormat.GoBackTextFormat),
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
                );
            html.Descendants("foo").Remove();
            return html.ToString();
        }


        protected override string GetPlainText(SystemTextSetting settings)
        {

            StringBuilder sb = new StringBuilder();


            if (HeaderText != null && HeaderText.Phrases.Count > 0)
                sb.AppendLine(HeaderText.Phrases.Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault())
                    .AppendLine();
            if (DisclaimerText != null && DisclaimerText.Phrases.Count > 0)
                sb.AppendLine(DisclaimerText.Phrases.Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault())
                    .AppendLine();
            if (TextFormat.DisplayChosenText)
                sb.AppendLine(
                     string.Format(
                                        settings.ChosenText.Content.Phrases
                                                .Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault().TrimEnd()
                                       ,
                                        OptionDisplayText.Phrases
                                                .Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault().TrimEnd()
                                  )
                    ).AppendLine();
            if (InformationalText != null && InformationalText.Phrases.Count > 0)
                sb.AppendLine(InformationalText.Phrases.Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault()).AppendLine();
            if (!DisableGoBackOption)
                sb.AppendLine(settings.PreviousMenuLevelCharacter + "." + settings.GoBackText.Content.Phrases
                                               .Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault()).AppendLine(); ;
            if (FooterText != null && FooterText.Phrases.Count > 0)
                sb.AppendLine(FooterText.Phrases.Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault());
            return sb.ToString();
        }


        public override InteractionResult Handle(string userInput, SystemTextSetting settings)
        {
            base.Handle(userInput, settings);
            if (!DisableGoBackOption && userInput.Equals(settings.PreviousMenuLevelCharacter))
                return new InteractionResult { Next = this.Parent, Type = InteractionResultType.GoBack };
            return new InteractionResult
            {
                Type = InteractionResultType.Invalid,
                Message = ConvertToMime(
                   settings.SelectionError.Content.Phrases
                       .Where(p => p.LanguageCode.Equals(this.LanguageCode))
                       .Select(p => p.Text).FirstOrDefault()
                       )
            };
        }
    }
}
