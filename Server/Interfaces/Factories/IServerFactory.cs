using Interfaces.ServerInterfaces;
using Interfaces.UserInterfaces;
using System.Net;
using System.Net.Sockets;

namespace Interfaces.Factories
{
    public interface IServerFactory
    {
        public IServer CreateServer(IPAddress ip, int port);
        public IMessage CreateMessage(IUser sender, string content);
        public IUser CreateUser(IPAddress ip, string username, string password, TcpClient client);
        public IRoom CreateRoom(string name, string password);

    }
}
