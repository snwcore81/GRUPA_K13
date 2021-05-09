using System;
using System.Collections.Generic;
using System.Text;
using GRUPA_K13.Classes;

namespace GRUPA_K13.Interfaces
{
    public interface IMessage
    {
        IMessage ProcessRequest(StateObject a_oStateObject = null);
        IMessage ProcessResponse(StateObject a_oStateObject = null);

        NetworkData AsNetworkData(int a_iDataSize = NetworkService.BUFFER_SIZE);
    }
}
