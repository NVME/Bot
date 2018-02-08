using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Core
{
    public class EnhancedChat
    {
        public EnhancedChat()
        {
            Console.WriteLine("Bot created");
        }
        public BotProfile BotProfile { get; set; }
        public Node Menu { get; set; }
        public Queue Queue { get; set; }

        public void Start()
        {
            Console.WriteLine("Bot starts");
        }
        public void Stop()
        {
            Console.WriteLine("Bot stops");
        }
        public void Drain()
        {
            Console.WriteLine("Bot drains");
        }

    }
}
