using System.Net.Sockets;

namespace Interfaces.ReadingInterfaces
{
    public interface IReader
    {
        public string ReadMessage(TcpClient client);
    }
}
