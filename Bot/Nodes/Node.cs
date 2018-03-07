
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
        public MimePartContentDescription Display(SystemTextSetting settings)
        {
            var package = new MimePartContentDescription(new ContentType("multipart/alternative"), null);
            package.Add(new MimePartContentDescription(new ContentType("text/plain"), Encoding.UTF8.GetBytes(GetPlainText(settings))));
            package.Add(new MimePartContentDescription(new ContentType("text/html"), Encoding.UTF8.GetBytes(GetHtmlText(settings))));
            return package;
        }
        public abstract string GetHtmlText(SystemTextSetting settings);
        public abstract string GetPlainText(SystemTextSetting settings);
        public abstract InteractionResult Handle(string userInput, SystemTextSetting settings);

        // This function converts HTML code to plain text
        // Any step is commented to explain it better
        // You can change or remove unnecessary parts to suite your needs
        public string HTMLToText(string HTMLCode)
        {
            // Remove new lines since they are not visible in HTML
            HTMLCode = HTMLCode.Replace("\n", " ");
            // Remove tab spaces
            HTMLCode = HTMLCode.Replace("\t", " ");
            // Remove multiple white spaces from HTML
            HTMLCode = Regex.Replace(HTMLCode, "\\s+", " ");
            // Replace special characters like &, <, >, " etc.
            StringBuilder sbHTML = new StringBuilder(HTMLCode);
            // Note: There are many more special characters, these are just
            // most common. You can add new characters in this arrays if needed
            string[] OldWords = {"&nbsp;", "&amp;", "&quot;", "&lt;","&gt;", "&reg;", "&copy;", "&bull;", "&trade;"};
            string[] NewWords = { " ", "&", "\"", "<", ">", "Â®", "Â©", "â€¢", "â„¢" };
            for (int i = 0; i < OldWords.Length; i++)
            {
                sbHTML.Replace(OldWords[i], NewWords[i]);
            }
            // Check if there are line breaks (<br>) or paragraph (<p>)           
            sbHTML.Replace("<br>", "\n<br>");
            sbHTML.Replace("<br ", "\n<br ");
            sbHTML.Replace("<p ", "\n<p ");
            // Finally, remove all HTML tags and return plain text
            return System.Text.RegularExpressions.Regex.Replace(
              sbHTML.ToString(), "<.*?>", string.Empty);
            //sbHTML.ToString(), "<[^>]*>", string.Empty);
            //.Replace(" 1","1");
        }
    }

    public class InteractionResult
    {
        public Node Next { get; set; }
        public string Message { get; set; }
        public ResultType Type { get; set; }
    }
    public enum ResultType
    {
        Matched,
        Invalid,
        GoBack,
        JumpTo,
        HandOff
    }
}
