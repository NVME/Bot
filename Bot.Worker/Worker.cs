
using Bot.Core;
using Bot.COMM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Worker
{
     public class Worker: IBotService
    {
        private EnhancedChat bot;
        private static object _objectForLock = new object();
        private static readonly Worker worker= new Worker();
        public static Worker Instance
        {
            get
            {
                return worker;
            }
        }

        private Worker()
        {
        }

        public void CreateBotService(BotEndpoint botEndpoint)
        {
            Console.WriteLine("Create Bot Service starts....");
            lock (_objectForLock)
            {
                if (IsCurrentBot(botEndpoint))
                {
                    throw new InvalidOperationException("You can not start another bot in different settings in the same process.");
                }           

                if (bot == null)
                {
                    bot = new EnhancedChat();
                   
                }             
            }
        }

        private bool IsCurrentBot(BotEndpoint botEndpoint)
        {
            return false;
        }

        public void StartBotService(BotEndpoint botEndpoint)
        {
            bot.Start();
        }

        public void StopBotService(BotEndpoint botEndpoint)
        {
            bot.Stop();
        }

        public void DrainBotService(BotEndpoint botEndpoint)
        {
            bot.Drain();
        }
    }
}
