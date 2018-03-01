
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

        public void CreateBotService(BotConfig config)
        {
            Console.WriteLine("Create Bot Service starts....");
            lock (_objectForLock)
            {
                if (IsCurrentBot(config))
                {
                    throw new InvalidOperationException("You can not start another bot in different settings in the same process.");
                }           

                if (bot == null)
                {
                    bot = new EnhancedChat();
                   
                }             
            }
        }

        private bool IsCurrentBot(BotConfig config)
        {
            return false;
        }

        public void StartBotService(BotConfig config)
        {
            bot.Start();
        }

        public void StopBotService(BotConfig config)
        {
            bot.Stop();
        }

        public void DrainBotService(BotConfig config)
        {
            bot.Drain();
        }
    }
}
