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
        void CreateBotService(BotEndpoint botEndpoint);
        [OperationContract]
        void StartBotService(BotEndpoint botEndpoint);
        [OperationContract]
        void StopBotService(BotEndpoint botEndpoint);
        [OperationContract]
        void DrainBotService(BotEndpoint botEndpoint);

    }
}

   
