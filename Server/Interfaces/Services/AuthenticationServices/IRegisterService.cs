using Interfaces.UserInterfaces;
using System.Net.Sockets;

namespace Interfaces.AuthenticationService
{
    public interface IRegisterService
    {
        public IUser Register(TcpClient clientSocket);
        public IUser AnonynousRegister();
    }
}
