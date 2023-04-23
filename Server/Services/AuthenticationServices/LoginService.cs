using Interfaces.AuthenticationService;
using Interfaces.PrintingInterfaces;
using Interfaces.ReadingInterfaces;
using Interfaces.ServerInterfaces;
using Interfaces.UserInterfaces;
using System.Net.Sockets;

namespace Services.AuthenticationServices
{
    public class LoginService : ILoginService
    {
        private readonly IServer _server;
        private readonly IPrint _print;
        private readonly IReader _reader;
        public LoginService(IServer server, IPrint print, IReader reader)
        {
            _print = print;
            _reader = reader;
            _server = server;
        }
        public IUser HandleLogin(TcpClient clientSocket)
        {
            _print.SendMessage(clientSocket, "Enter username:");
            string username = _reader.ReadMessage(clientSocket);
            _print.SendMessage(clientSocket, "Enter password:");
            string password = _reader.ReadMessage(clientSocket);
            IUser user = _server.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                _print.SendMessage(clientSocket, "Login successful.");
                return user;
            }
            _print.SendMessage(clientSocket, "Invalid username or password.");
            return null;
        }
        public void InvalidCommand(TcpClient client)
        {
            _print.SendMessage(client, "Invalid command. Type /register for register and /login for login.");
        }
    }
}
