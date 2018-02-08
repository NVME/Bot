using Bot;
using Microsoft.Owin.Hosting;
using System;


namespace Bot.Master
{
    class Program
    {
        public const string BotAppProcessName = "Bot";
        private const string BotAppName = BotAppProcessName + ".exe";
        private static string processid="";
       
        static void Main(string[] args)
        {
            Console.Title = "This is Bot Manager";          
           
            // Console.ReadLine();
            Console.WriteLine("start web api");
            string domainAddress = "http://localhost:9000/";

            using (WebApp.Start<Startup>(url: domainAddress))
            {
                Console.WriteLine("Service Hosted " + domainAddress);
                System.Threading.Thread.Sleep(-1);
            }
            Console.ReadLine();


        }

       
    }
}
