using Interfaces.PrintingInterfaces;
using Interfaces.ServerInterfaces;
using Interfaces.Services.AuthenticationService;
using Interfaces.Services.RoomServices;
using Interfaces.UserInterfaces;
using System.Net.Sockets;

namespace Services.RoomServices
{
    public class CommandHandler : ICommandHandler
    {
        private readonly IPrint _print;
        private readonly IHandler _authenticationHandler;
        private readonly IServer _server;
        public CommandHandler(IPrint print, IHandler authenticationHandler, IServer server)
        {
            _print = print;
            _authenticationHandler = authenticationHandler;
            _server = server;
        }

        public void HandleCommand(string message, IUser user, IRoom room)
        {
            switch (message)
            {
                case "/quit":
                case "quit":
                    _authenticationHandler.LogOut(user);
                    break;
                case "/history":
                case "history":
                    GetHistory(user, room);
                    break;
                case "/commands":
                case "commands":
                    _print.AllCommands(user);
                    break;
                case "/rooms":
                case "rooms":
                    AllRooms(_server, user);
                    break;
                default:
                    _print.BroadcastMessage(user, message, room.Users);
                    break;
            }
        }
        public IUser Authenticate(string message, TcpClient client)
        {
            return _authenticationHandler.HandleClient(message, client);
        }
        private void GetHistory(IUser user, IRoom room)
        {
            foreach (var item in room.History.OrderBy(m => m.SendAt).ToList())
            {
                _print.SendMessage(user.Client, $"{item.Sender.Username}: {item.Content}");
            }
        }
        private void AllRooms(IServer server, IUser user)
        {
            _print.SendMessage(user.Client, "Rooms:");
            foreach (var room in server.Rooms)
            {
                _print.SendMessage(user.Client, room.Name);
            }
        }
    }
}
