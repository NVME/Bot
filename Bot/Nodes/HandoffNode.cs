using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bot.COMM;
using System.Xml.Linq;

namespace Bot.Core
{
    public class HandoffNode : Node, INode
    {
        public HandoffNode() : base() { }
        public GlobalPhrase HeaderText { get; set; }
        public GlobalPhrase DisclaimerText { get; set; }//// can be override by GlobalDisclaimer, TBD: Deceide how /when to override , on configure manager side or bot .
        public Queue Queue { get; set; }
        public bool ShowConfirmation { get; set; }
        //public bool DisableGoBackOption { get; set; }//No, you cannot disable the “Go Back” option for the handoff node. It wouldn’t make any sense. The only reason to show the confirmation screen (pictured below) is to allow the user the change to change their mind before transferring to an agent.
        public bool DisplayConnectionText { get; set; }
        public bool DisplayHoursOfOperation { get; set; }

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

                 !DisplayConnectionText ?//Determines if the standard connecting message is displayed. Default is true.
                  new XElement("foo") :
                  new XElement("div",
                                 new XElement("span", new XAttribute("style", TextFormat.MenuNumberTextFormat), new XText("1.")),
                                 new XElement("span", new XAttribute("style", TextFormat.MenuOptionTextFormat),
                                       new XElement("span", settings.HandoffConfirmationText.Content.Phrases
                                                          .Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault()
                                                    )
                                             ),
                                 new XElement("br")
                              ),
                  // display go back option.
                   new XElement("div",
                                  new XElement("span", new XText(settings.PreviousMenuLevelCharacter + ".")),
                                  new XElement("span", new XAttribute("style", TextFormat.GoBackTextFormat),
                                        new XElement("span",
                                                   settings.GoBackText.Content.Phrases
                                                             .Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault()
                                                     )
                                            ),
                              new XElement("br")
                             )
            );
            html.Descendants("foo").Remove();
            return html.ToString();
        }
        public override string GetOptionDisplayText(string languageCode)
        {
            StringBuilder sbHoursOfOperation = new StringBuilder(base.GetOptionDisplayText(languageCode));
            if (Queue == null) return sbHoursOfOperation.ToString();
            var workday = Queue.HoursOfOperation.WorkDays.First<WorkDay>(d => d.Day == DateTime.UtcNow.DayOfWeek);
            if (workday != null)
            {
                foreach (var s in workday.WorkShifts)
                {
                    sbHoursOfOperation.Append(s.ToString());
                    sbHoursOfOperation.Append(" ");
                }
            }
            return sbHoursOfOperation.ToString();
        }

        public override string GetPlainText(SystemTextSetting settings)
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
            if (TextFormat.DisplaySelectionText)
                sb.AppendLine(settings.SelectionText.Content.Phrases
                                                 .Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault())
                     .AppendLine();
            if (DisplayConnectionText)
                sb.AppendLine("1." + settings.HandoffConfirmationText.Content.Phrases
                                            .Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault());
            sb.AppendLine(settings.PreviousMenuLevelCharacter + "." + settings.GoBackText.Content.Phrases
                                           .Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault());
            return sb.ToString();
        }

        public override InteractionResult Handle(string userInput)
        {
            throw new NotImplementedException();
        }


    }
}
