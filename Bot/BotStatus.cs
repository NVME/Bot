using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Core
{
    public class BotStatus
    {
        public int BotId { get; set; }

        public int StatusId { get; set; }// (from list of possible options)The current status of the bot, as reported to the Configuration Manager by the UCMA application.Bots in the "Ready" state are considered active bots.
        public DateTime LastReady { get; set; }// dateTime Marks the last time the bot was in the "Ready" state.Record this time whenever the UCMA application signals a change from "Ready" to another state.
        public DateTime LastStateChange { get; set; }//dateTime Marks the time when the current state was signaled by the UCMA application.		
        public int ActiveSessionsCount { get; set; }// int The number of active IM calls for the bot.
        public int ActiveVASessionsCount { get; set; }// The number of active Virtual Agent sessions.
        public int ActiveAicSessionsCount { get; set; }// int The number of active AIC XMPP sessions.	
        public int ActiveSNowSessionsCount { get; set; } //The number of active Service Now chat sessions.
    }
}
