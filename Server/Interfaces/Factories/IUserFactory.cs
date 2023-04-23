using Interfaces.UserInterfaces;
using System.Net;
using System.Net.Sockets;

namespace Interfaces.Factories
{
    public interface IUserFactory
    {
        public IUser CreateUser(IPAddress ip, string username, string password, TcpClient client);
    }
}
