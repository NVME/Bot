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
        void IBotService.CreateBotService(BotConfig config)
        {
            try
            {
                Worker.Instance.CreateBotService(config);
            }
            catch (Exception ex)
            {

                Console.WriteLine( ex);
            }
          
                  

           
        }

        void IBotService.StartBotService(BotConfig config)
        {
            
            Worker.Instance.StartBotService(config);
           
        }

        void IBotService.StopBotService(BotConfig config)
        {
           
            Worker.Instance.StopBotService(config);
            
        }

        void IBotService.DrainBotService(BotConfig config)
        {
            
            Worker.Instance.DrainBotService(config);
           
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
