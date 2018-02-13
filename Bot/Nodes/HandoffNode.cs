using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bot.COMM;
using System.Xml.Linq;

namespace Bot.Core
{
    public class HandoffNode : Node,INode
    {
        public HandoffNode() : base() { }
        public Header Header { get; set; }
        public Disclaimer Disclaimer { get; set; }       
        public Queue Queue { get; set; }
        public bool ShowConfirmation { get; set; }
        public bool DisplayHoursOfOperation { get; set; }

        public override string Display()
        {
            return new XElement("div",
                    Header == null || Header.Text == null || Header.Text.Phrases.Count == 0 ?  // Header section
                    new XElement("foo") :// if header is empty, display <foo/>
                    new XElement("div",
                        new XElement("span", new XAttribute("style", string.IsNullOrEmpty(Header.Format) ?
                                                                     DefaultSettingSingleton.Instance.HeaderTextFormat : Header.Format),
                          new XElement("span",
                            Header.Text.Phrases.Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault()
                            )
                      ),
                          new XElement("br"),
                          new XElement("br")
                      ),
                     Disclaimer == null || Disclaimer.Text == null || Disclaimer.Text.Phrases.Count == 0 ?  // Disclaimer section
                     new XElement("foo") :  //if Disclaimer is empty, display < foo />
                     new XElement("div",
                         new XElement("span", new XAttribute("style", string.IsNullOrEmpty(Disclaimer.Format) ?
                                                                    DefaultSettingSingleton.Instance.DisclaimerTextFormat : Disclaimer.Format),
                            new XElement("span",
                                Disclaimer.Text.Phrases.Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault()
                                )
                          ),
                          new XElement("br"),
                          new XElement("br")
                      ),
                     !ShowConfirmation ?//Message used to verify that a user wants to be connected to a live agent.
                      new XElement("foo") :
                      new XElement("div",
                          new XElement("span", new XAttribute("style", DefaultSettingSingleton.Instance.BodyTextFormat),
                                    new XElement("span",
                                       DefaultSettingSingleton.Instance.SystemTextSettings.HandoffConfirmationText.Content.Phrases
                                                .Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault()
                                        )
                          )                       
                     )


                ).ToString().Replace("<foo />", string.Empty);
        }
        public override string GetOptionDisplayText(string languageCode)
        {
            StringBuilder sbHoursOfOperation = new StringBuilder(base.GetOptionDisplayText(languageCode));
            var workday = Queue.HoursOfOperation.WorkDays.First<WorkDay>(d => d.Day == DateTime.UtcNow.DayOfWeek);
            if(workday!=null)
            {
                foreach (var s in workday.WorkShifts)
                {                    
                    sbHoursOfOperation.Append(s.ToString());
                    sbHoursOfOperation.Append(" ");
                }
            }
            return sbHoursOfOperation.ToString() ;
        }
        public override KeyValuePair<Node, string> Handle(string userInput)
        {
            throw new NotImplementedException();
        }
    }
}
