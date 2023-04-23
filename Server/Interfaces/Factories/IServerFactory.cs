using Interfaces.ServerInterfaces;
using System.Net;

namespace Interfaces.Factories
{
    public interface IServerFactory
    {
        public IServer CreateServer(IPAddress ip, int port);
    }
}
