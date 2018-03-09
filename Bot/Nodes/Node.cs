
using System;
using System.Collections.Generic;
using Bot.COMM;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.Rtc.Collaboration;
using System.Net.Mime;

namespace Bot.Core
{
    public abstract class Node : INode
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public Node Parent { get; set; }
        public FormattingOptions TextFormat { get; set; }
        public GlobalPhrase OptionDisplayText { get; set; }
        public List<GlobalPhrase> Keywords { get; set; }
        public string LanguageCode { get; set; }
        public string CweCommand { get; set; }
        public string AdditionalOptions { get; set; }
        public bool IsRootNode { get; set; }
        public bool IsLanguageNode { get; set; }
        protected Node()
        {
            LanguageCode = "en-us";// default language, will be reset in language node and pass to next node;
            Keywords = new List<GlobalPhrase>();
            IsRootNode = false;
            IsLanguageNode = false;
        }
        public virtual string GetOptionDisplayText(string languageCode)
        {
            return OptionDisplayText.Phrases.Where(l => l.LanguageCode.Equals(this.LanguageCode)).Select(p => p.Text).FirstOrDefault();
        }
        public virtual DisplayResult Display(SystemTextSetting settings)
        {
            var plainText = GetPlainText(settings);
            var html = GetHtmlText(settings);
            //var package = new MimePartContentDescription(new ContentType("multipart/alternative"), null);
            //package.Add(new MimePartContentDescription(new ContentType("text/plain"), Encoding.UTF8.GetBytes(plainText)));
            //package.Add(new MimePartContentDescription(new ContentType("text/html"), Encoding.UTF8.GetBytes(html)));
            //return new DisplayResult { Message = package, Type = DisplayResultType.Display, Html = html, PlainText = plainText };
            return new DisplayResult { Message = null, Type = DisplayResultType.Display, Html = html, PlainText = plainText };
        }
        protected abstract string GetHtmlText(SystemTextSetting settings);
        protected abstract string GetPlainText(SystemTextSetting settings);
        public virtual InteractionResult Handle(string userInput, SystemTextSetting settings)
        {
            //TBD: Check by pass agent

            //return invalid selection by default
            return new InteractionResult
            {
                Type = InteractionResultType.Invalid
                //,
                //Message = ConvertToMime(
                //   settings.SelectionError.Content.Phrases
                //      .Where(p => p.LanguageCode.Equals(this.LanguageCode))
                //      .Select(p => p.Text).FirstOrDefault()
                //       )
            };
        }

        private MimePartContentDescription ConvertToMime(string msg)
        {

            var package = new MimePartContentDescription(new ContentType("multipart/alternative"), null);
            var htm = string.Format("<span style=\"{1} \"><span>{0}</span></span>", msg, this.TextFormat.ErrorTextFormat);
            package.Add(new MimePartContentDescription(new ContentType("text/plain"), Encoding.UTF8.GetBytes(msg)));
            package.Add(new MimePartContentDescription(new ContentType("text/html"), Encoding.UTF8.GetBytes(htm)));
            return package;
        }     
    }


    public class MimeResult
    {
        public MimePartContentDescription Message { get; set; }
        public string Html { get; set; }// for testing
        public string PlainText { get; set; }// for testing
    }

    public class InteractionResult : MimeResult
    {
        public Node Next { get; set; }
        public InteractionResultType Type { get; set; }
    }

    public class DisplayResult : MimeResult
    {
        public DisplayResultType Type { get; set; }
    }
    public enum InteractionResultType
    {
        Matched,
        Invalid,
        GoBack,
        JumpTo,
        HandOff,
        AgentByPass
    }

    public enum DisplayResultType
    {
        NodeLinkNoDisplay,
        HandOffNoConfirmation,
        Display

    }
}
