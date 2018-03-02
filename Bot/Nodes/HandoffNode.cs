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
        public GlobalPhrase DisclaimerText { get; set; }
        public Queue Queue { get; set; }
        public bool ShowConfirmation { get; set; }
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
                 !ShowConfirmation ?//Message used to verify that a user wants to be connected to a live agent.
                  new XElement("foo") :
                  new XElement("div",
                      new XElement("span", new XAttribute("style", TextFormat.BodyTextFormat),
                                new XElement("span",
                                  settings.HandoffConfirmationText.Content.Phrases
                                            .Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault()
                                    )
                      )
                 )


            );
            html.Descendants("foo").Remove();
            return html.ToString();
        }
        public override string GetOptionDisplayText(string languageCode)
        {
            StringBuilder sbHoursOfOperation = new StringBuilder(base.GetOptionDisplayText(languageCode));
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
        public override InteractionResult Handle(string userInput)
        {
            throw new NotImplementedException();
        }

        public override string GetPlainText(SystemTextSetting settings)
        {
            throw new NotImplementedException();
        }
    }
}
