using System.Collections.Generic;

namespace Bot.Core
{
     interface INode
    {
        /// <summary> Gets node's UI/Display. </summary>
        /// <returns></returns>
         string Display();
        /// <summary>
        /// 
        /// Hand user input, return next node, if no next node , retrun it self and message.
        /// </summary>
        /// <param name="sMessage"></param>
        /// <returns></returns>
        KeyValuePair<Node, string> Handle(string sMessage);
    }
}