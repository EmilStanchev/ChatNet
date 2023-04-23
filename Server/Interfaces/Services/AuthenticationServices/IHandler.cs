using Interfaces.UserInterfaces;
using System.Net.Sockets;

namespace Interfaces.Services.AuthenticationService
{
    public interface IHandler
    {
        public IUser HandleClient(string message, TcpClient client);
        public void LogOut(IUser user);
    }
}
