using Interfaces.UserInterfaces;
using System.Net.Sockets;

namespace Interfaces.AuthenticationService
{
    public interface ILoginService
    {
        public IUser HandleLogin(TcpClient clientSocket);
        public void InvalidCommand(TcpClient client);
    }
}
