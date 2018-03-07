using Bot.COMM;
using Microsoft.Rtc.Collaboration;

namespace Bot.Core
{
     interface INode
    {
        /// <summary> Gets node's UI/Display. </summary>
        /// <returns></returns>
        MimePartContentDescription Display( SystemTextSetting settings);
        /// <summary>
        /// 
        /// Hand user input, return next node, if no next node , retrun it self and message.
        /// </summary>
        /// <param name="sMessage"></param>
        /// <returns></returns>
        InteractionResult Handle(string sMessage, SystemTextSetting settings);
    }
}