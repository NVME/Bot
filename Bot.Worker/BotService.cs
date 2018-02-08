using Bot.COMM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Worker
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class BotService : IBotService
    {
        void IBotService.CreateBotService(BotEndpoint botEndpoint)
        {
            try
            {
                Worker.Instance.CreateBotService(botEndpoint);
            }
            catch (Exception ex)
            {

                Console.WriteLine( ex);
            }
          
                  

           
        }

        void IBotService.StartBotService(BotEndpoint botEndpoint)
        {
            
            Worker.Instance.StartBotService(botEndpoint);
           
        }

        void IBotService.StopBotService(BotEndpoint botEndpoint)
        {
           
            Worker.Instance.StopBotService(botEndpoint);
            
        }

        void IBotService.DrainBotService(BotEndpoint botEndpoint)
        {
            
            Worker.Instance.DrainBotService(botEndpoint);
           
        }

        public static void Notify(Notification notification)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var task = client.PostAsJsonAsync("http://localhost:9000/api/bot/notify", notification);

                    if (!task.Result.IsSuccessStatusCode )
                    {
                        Console.WriteLine("post failed");
                    }
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
        }        
    }

    
}
