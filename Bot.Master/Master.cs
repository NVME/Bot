using Bot.COMM;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;


namespace Bot.Master
{
  public  class Master
    {
        private static Dictionary<int, string> processList = new Dictionary<int, string>();

        public static void Create(BotProfileDto bot,List<NodeDto> nodes, QueueDto queue)
        {
            Console.WriteLine("Creating a bot process.... might take 5 seconds..");
            if (processList.ContainsKey(bot.Id)) throw new ApplicationException("Already exists");
            using (Process botProcess = new Process())
            {
                botProcess.StartInfo = new ProcessStartInfo("bot.exe");
                botProcess.StartInfo.Arguments = bot.Name;
                //ssnavBotAppProcess.StartInfo.UseShellExecute = false;
                botProcess.Start();
                processList.Add(bot.Id, botProcess.Id.ToString());
                System.Threading.Thread.Sleep(5000);
            }
            Console.WriteLine("Press to create a bot");
            Console.ReadLine();            
            string processid = processList[bot.Id];
            NetNamedPipeBinding netNamedPipeBinding = new NetNamedPipeBinding();
            netNamedPipeBinding.ReceiveTimeout = new TimeSpan(0, 20, 0);
            netNamedPipeBinding.SendTimeout = new TimeSpan(0, 10, 0);
            using (var factory = new ChannelFactory<IBotService>(netNamedPipeBinding,
                new EndpointAddress(new Uri("net.pipe://localhost/snav/bot/endpoint/" + processid))))
            {
                var botService = factory.CreateChannel();
                botService.CreateBotService(new BotEndpoint() {  BotProfile=bot,Nodes=nodes,Queue=queue});
            }
            Console.WriteLine("Request sent out!");

        }

       
        public static void Start(int Id)
        {
            Console.WriteLine("start a bot");
            string processid = processList[Id];
            NetNamedPipeBinding netNamedPipeBinding = new NetNamedPipeBinding();
            netNamedPipeBinding.ReceiveTimeout = new TimeSpan(0, 20, 0);
            netNamedPipeBinding.SendTimeout = new TimeSpan(0, 10, 0);
            using (var factory = new ChannelFactory<IBotService>(netNamedPipeBinding, 
                new EndpointAddress(new Uri("net.pipe://localhost/snav/bot/endpoint/" + processid))))
            {
                var botService = factory.CreateChannel();
                botService.StartBotService(new BotEndpoint());
            }
        }

        public static void Stop(int Id)
        {
            Console.WriteLine("start a bot");
            string processid = processList[Id];
            NetNamedPipeBinding netNamedPipeBinding = new NetNamedPipeBinding();
            netNamedPipeBinding.ReceiveTimeout = new TimeSpan(0, 20, 0);
            netNamedPipeBinding.SendTimeout = new TimeSpan(0, 10, 0);
            using (var factory = new ChannelFactory<IBotService>(netNamedPipeBinding, 
                new EndpointAddress(new Uri("net.pipe://localhost/snav/bot/endpoint/" + processid))))
            {
                var botService = factory.CreateChannel();
                botService.StopBotService(new BotEndpoint());
            }
        }

        public static void Drain(int Id)
        {
            Console.WriteLine("start a bot");
            string processid = processList[Id];
            NetNamedPipeBinding netNamedPipeBinding = new NetNamedPipeBinding();
            netNamedPipeBinding.ReceiveTimeout = new TimeSpan(0, 20, 0);
            netNamedPipeBinding.SendTimeout = new TimeSpan(0, 10, 0);
            using (var factory = new ChannelFactory<IBotService>(netNamedPipeBinding,
                new EndpointAddress(new Uri("net.pipe://localhost/snav/bot/endpoint/" + processid))))
            {
                var botService = factory.CreateChannel();
                botService.DrainBotService(new BotEndpoint());
            }
        }
    }
}
