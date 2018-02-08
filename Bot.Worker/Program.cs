using Bot;
using Bot.COMM;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bot.Worker
{
    class Program
    {
        private static AutoResetEvent _autoResetEvent = new AutoResetEvent(false);

        private static System.Timers.Timer timer;
        
        public static void Exit()
        {
            _autoResetEvent.Set();
        }

        static void Main(string[] args)
        {
            // disable crash error dialog in window
            NativeMethods.SetErrorMode(NativeMethods.SetErrorMode(ErrorModes.SEM_NOGPFAULTERRORBOX)
                | ErrorModes.SEM_FAILCRITICALERRORS
                | ErrorModes.SEM_NOGPFAULTERRORBOX);

            
            Console.WriteLine("Worker process Created");
            Console.WriteLine("Creating WCF services");
            //Console.ReadLine();
            string processID = Process.GetCurrentProcess().Id.ToString();
            // Create a service host with an named pipe endpoint
            using (var host = new ServiceHost(typeof(BotService), new Uri("net.pipe://localhost/snav/bot/endpoint/" + processID)))
            {
                NetNamedPipeBinding npb = new NetNamedPipeBinding();
                npb.ReceiveTimeout = new TimeSpan(0, 20, 0);
                npb.SendTimeout = new TimeSpan(0, 10, 0);
                host.AddServiceEndpoint(typeof(IBotService), npb, "");
                host.Open();
                Console.WriteLine("Bot WCF Services Created:"+processID);
               
                //timer = new System.Timers.Timer(3000);
                //timer.Elapsed += (sender, e) => HandleTimer(sender, e);
                //timer.Start();
                //Console.WriteLine("Boom clicks");
                _autoResetEvent.WaitOne();

                host.Close();
            }

            

        }

        private static  void HandleTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            timer.Stop();
            try
            {
                Console.WriteLine("\nHandler not implemented...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                BotService.Notify(new Notification { Message = ex.StackTrace });
                
            }        
        }
    }
}
