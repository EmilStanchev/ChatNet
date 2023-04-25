using System.Net.Sockets;

namespace Interfaces.ServerInterfaces
{
    public interface IServerOperations
    {
        public TcpListener Listener();
        public void HandleClient(object client);

    }
}
