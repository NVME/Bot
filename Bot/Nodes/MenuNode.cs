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
        public GlobalPhrase DisclaimerText { get; set; }//// can be override by GlobalDisclaimer, TBD: Deceide how /when to override , on configure manager side or bot .
        public GlobalPhrase FooterText { get; set; }
        public List<Node> Nodes { get; set; }
        public bool DisableGoBackOption { get; set; }
        public bool HideMenu { get; set; }
        public bool HideMenuNumbers { get; set; }


        protected override string GetHtmlText(BotSettingMini settings)
        {
            var html = new XElement("div",
                     !TextFormat.DisplayChosenText ?//if display chosen text is false, display < foo />
                       new XElement("foo") :
                       new XElement("div",  // display chose text ,Ex. "You have chosen Password Reset."
                           new XElement("span", new XAttribute("style", TextFormat.BodyTextFormat),
                                     new XElement("span",
                                       string.Format(
                                              settings.SystemTexts.ChosenText.Content.Phrases
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
                      !TextFormat.DisplaySelectionText ?//if display selection text is false, display < foo />
                       new XElement("foo") :
                       new XElement("div",
                           new XElement("span", new XAttribute("style", TextFormat.BodyTextFormat),
                                     new XElement("span",
                                       settings.SystemTexts.SelectionText.Content.Phrases
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
                             !DisableGoBackOption ?//if display go back text is false, display < foo />
                                 new XElement("foo") :
                                 new XElement("div",
                                       new XElement("span",
                                                         new XText(settings.SystemTexts.PreviousMenuLevelCharacter + ".")
                                                         ),
                                       new XElement("span", new XAttribute("style", TextFormat.GoBackTextFormat),
                                                 new XElement("span",
                                                   settings.SystemTexts.GoBackText.Content.Phrases
                                                             .Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault()
                                                     )
                                            ),
                              new XElement("br")
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

        protected override string GetPlainText(BotSettingMini settings)
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
                                        settings.SystemTexts.ChosenText.Content.Phrases
                                                .Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault().TrimEnd()
                                       ,
                                        OptionDisplayText.Phrases
                                                .Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault().TrimEnd()
                                  )
                    ).AppendLine();
            if (TextFormat.DisplaySelectionText)
                sb.AppendLine(settings.SystemTexts.SelectionText.Content.Phrases
                                                 .Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault())
                     .AppendLine();
            if (!HideMenu && Nodes != null)
            {
                foreach (var o in Nodes.Select((node, index) => new { node, index }))
                    sb.AppendLine((o.index + 1).ToString() + "." + o.node.GetOptionDisplayText(this.LanguageCode));
                if (!DisableGoBackOption)
                    sb.AppendLine(settings.SystemTexts.PreviousMenuLevelCharacter + "." + settings.SystemTexts.GoBackText.Content.Phrases
                                                       .Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault());
                sb.AppendLine();
            }
            if (FooterText != null && FooterText.Phrases.Count > 0)
                sb.AppendLine(FooterText.Phrases.Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault());

            return sb.ToString();
        }

        public override InteractionResult Handle(string userInput, BotSettingMini settings)
        {
            var input = userInput.Trim();
            var result = base.Handle(input, settings);
            if (result.Type != InteractionResultType.Invalid) return result;
            int index; Node next = null;
            if (!DisableGoBackOption && input.Equals(settings.SystemTexts.PreviousMenuLevelCharacter))
                return new InteractionResult { Next = this.Parent, Type = InteractionResultType.GoBack };
            else if (int.TryParse(input, out index))
                next = this.Nodes.Where((n, idx) => idx+1 == index).FirstOrDefault();
            else
                next = this.Nodes.Where(
                                 n => n.Keywords.Where(
                                                 key => key.Phrases.Where(
                                                                           p => p.LanguageCode.Equals(this.LanguageCode)
                                                                         )
                                                                   .Select(p => p.Text).Contains(input)
                                                      ).Count() > 0
                                      ).FirstOrDefault();

            if (next != null)
            {
                next.LanguageCode = this.LanguageCode; // follow the same language code
                return new InteractionResult { Next = next, Type = InteractionResultType.Matched };
            }
            return result;
                
        }
    }


}
