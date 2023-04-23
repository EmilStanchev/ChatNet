using System.Net.Sockets;

namespace Interfaces.ServerInterfaces
{
    public interface IServerOperations
    {
        public TcpListener Listener();
        public void HandleClientComm(object client);

    }
}
