using Interfaces.AuthenticationService;
using Interfaces.ReadingInterfaces;
using Interfaces.Services.AuthenticationService;
using Interfaces.UserInterfaces;
using System.Net.Sockets;

namespace Services.AuthenticationServices
{
    public class Handler : IHandler
    {
        private readonly ILoginService _login;
        private readonly IRegisterService _register;
        private readonly IReader _reader;
        public Handler(ILoginService login, IRegisterService register, IReader reader)
        {
            _login = login;
            _register = register;
            _reader = reader;
        }
        public IUser HandleClient(string message, TcpClient client)
        {
            IUser user;
            while (true)
            {
                switch (message)
                {
                    case "login":
                    case "/login":
                        user = _login.HandleLogin(client);
                        break;
                    case "register":
                    case "/register":
                        user = _register.Register(client);
                        break;
                    default:
                        _login.InvalidCommand(client);
                        user = null;
                        break;
                }

                // Exit the loop if a valid command was processed
                if (user != null) break;
                message = _reader.ReadMessage(client);
            }
            return user;
        }
        public void LogOut(IUser user)
        {
            user.Client.Client.Shutdown(SocketShutdown.Both);

        }
    }
}
