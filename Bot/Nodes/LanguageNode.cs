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
        public GlobalPhrase DisclaimerText { get; set; }// can be override by GlobalDisclaimer, TBD: Deceide how /when to override , on configure manager side or bot .
        public GlobalPhrase FooterText { get; set; }
        public List<LanguageOption> LanguageOptions { get; set; }
        public bool UseEnglishLanguageName { get; set; }
        public LanguageNode() : base()
        {
            LanguageOptions = new List<LanguageOption>();
        }

        protected override string GetHtmlText(BotSettingMini settings)
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
                                                         string.IsNullOrEmpty(l.LanguageAltText) ?
                                                         new XElement("span", UseEnglishLanguageName ? l.Language.EnglishName : l.Language.LocalName)
                                                         :
                                                         new XElement("span", l.LanguageAltText)
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
                          ),//If footer text has been defined, the bypass message message should be appended to that text, and separated by a line break.
                        !settings.MenuBypass.DisplayMenuBypassMessage || settings.MenuBypass.BypassKeywords.Count == 0 ?
                         new XElement("foo") :
                         new XElement("hr")
                       ),
                      !settings.MenuBypass.DisplayMenuBypassMessage || settings.MenuBypass.BypassKeywords.Count == 0 ?
                        new XElement("foo") : //
                         new XElement("div",
                         new XElement("span", new XAttribute("style", TextFormat.BodyTextFormat),
                           new XElement("span",  // display by pass text. SystemTextSettings.AgentBypassText is where the message is defined. It will need a placeholder for the first word in the bypasskeywords settings. Something like “To chat with an agent directly, type “{0)” at any time”.
                             string.Format(
                                            settings.SystemTexts.AgentBypassText.Content.Phrases
                                                .Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault().TrimEnd(),
                                           settings.MenuBypass.BypassKeywords[0].Phrases
                                                .Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault()
                                          )
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
            if (LanguageOptions != null)
            {
                foreach (var node in LanguageOptions.Select((l, i) => new { l, i }))
                    sb.AppendLine(
                        (node.i + 1).ToString() + "." + (
                        string.IsNullOrEmpty(node.l.LanguageAltText) ?
                        (UseEnglishLanguageName ? node.l.Language.EnglishName : node.l.Language.LocalName)
                        :
                        node.l.LanguageAltText
                        )
                     );
                sb.AppendLine();
            }
            if (FooterText != null && FooterText.Phrases.Count > 0)
                sb.AppendLine(FooterText.Phrases.Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault()).AppendLine();
            if (settings.MenuBypass.DisplayMenuBypassMessage && settings.MenuBypass.BypassKeywords.Count > 0)
                sb.AppendLine(
                       string.Format(
                                            settings.SystemTexts.AgentBypassText.Content.Phrases
                                                    .Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault().TrimEnd()
                                           ,
                                            settings.MenuBypass.BypassKeywords[0].Phrases
                                                    .Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault()
                                      )
                        );
            return sb.ToString();
        }

        public override InteractionResult Handle(string userInput, BotSettingMini settings)
        {
            var input = userInput.Trim();
            var result = base.Handle(input, settings);
            if (result.Type != InteractionResultType.Invalid) return result;
            int index; LanguageOption option = null;
            if (int.TryParse(input, out index))
                option = this.LanguageOptions.Where((ln, idx) => idx+1 == index).FirstOrDefault();
            else
                option = this.LanguageOptions
                    .Where(op =>
                    op.Keywords.Contains(input)
                    ||
                    op.Language.keywords.Contains(input)
                    ).FirstOrDefault();

            if (option != null && option.TargetNode != null)
            {
                option.TargetNode.LanguageCode = option.Language.LanguageCode; // update language code;
                return new InteractionResult { Next = option.TargetNode, Type = InteractionResultType.Matched };
            }
            return result; //return invalid selection
        }
    }


    public class LanguageOption
    {
        public Language Language { get; set; }
        public int TargetNodeId { get; set; }
        public Node TargetNode { get; set; }
        public string LanguageAltText { get; set; }
        public List<string> Keywords { get; set; }
    }
}
