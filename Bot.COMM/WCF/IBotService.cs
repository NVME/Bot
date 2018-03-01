using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bot.COMM
{
    [ServiceContract]
    public interface IBotService
    {
        [OperationContract]
        void CreateBotService(BotConfig config);
        [OperationContract]
        void StartBotService(BotConfig config);
        [OperationContract]
        void StopBotService(BotConfig config);
        [OperationContract]
        void DrainBotService(BotConfig config);

    }
}

   
