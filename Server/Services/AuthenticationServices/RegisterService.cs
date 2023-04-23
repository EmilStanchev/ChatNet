using Interfaces.AuthenticationService;
using Interfaces.Factories;
using Interfaces.PrintingInterfaces;
using Interfaces.ReadingInterfaces;
using Interfaces.ServerInterfaces;
using Interfaces.UserInterfaces;
using System.Net;
using System.Net.Sockets;

namespace Services.AuthenticationServices
{
    public class RegisterService : IRegisterService
    {
        private readonly IServer _server;
        private readonly IPrint _print;
        private readonly IReader _reader;
        private readonly IUserFactory _userFactory;

        public RegisterService(IServer server, IPrint print, IReader reader, IUserFactory factory)
        {
            _print = print;
            _server = server;
            _reader = reader;
            _userFactory = factory;
        }
        public IUser Register(TcpClient clientSocket)
        {
            _print.SendMessage(clientSocket, "Enter username:");
            string username = _reader.ReadMessage(clientSocket);
            _print.SendMessage(clientSocket, "Enter password:");
            string password = _reader.ReadMessage(clientSocket);
            IPAddress ipAddress = ((IPEndPoint)clientSocket.Client.RemoteEndPoint).Address;
            IUser user = _userFactory.CreateUser(ipAddress, username, password, clientSocket);
            _server.Users.Add(user);
            _print.SendMessage(clientSocket, "Registration successful. You are now logged in.");

            return user;
        }
        public IUser AnonynousRegister()
        {
            return _userFactory.CreateUser(IPAddress.Any, "Anonymous", "1212", new TcpClient());
        }
    }
}
