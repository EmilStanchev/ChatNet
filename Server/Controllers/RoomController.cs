using Interfaces.ControllerInterfaces;
using Interfaces.ReadingInterfaces;
using Interfaces.ServerInterfaces;
using Interfaces.Services.RoomServices;
using Interfaces.UserInterfaces;
using System.Net.Sockets;

namespace Controllers
{
    public class RoomController : IRoomContoller
    {
        private readonly IRoomOperations _roomService;
        private readonly ICommandHandler _commandHandler;
        private readonly IReader _reader;
        public RoomController(IRoomOperations roomService, IReader reader, ICommandHandler commandHandler)
        {
            _roomService = roomService;
            _reader = reader;
            _commandHandler = commandHandler;
        }
        public IRoom Handler(TcpClient client, IUser user, string message)
        {
            IRoom room = null;
            while (true)
            {
                switch (message)
                {
                    case "/create":
                    case "create":
                        room = _roomService.CreateRoom(user.Client, user);
                        break;
                    case "/join":
                    case "join":
                        room = _roomService.JoinRoom(user, user.Client);
                        break;
                    default:
                        _roomService.InvalidCommand(user.Client);
                        room = null;
                        break;
                }
                if (room != null) break;
                message = _reader.ReadMessage(user.Client);
            }
            return room;

        }
        public void AddMessageToHistory(IUser user, string message, IRoom room)
        {
            _roomService.AddToHistory(user, message, room);
        }
        public void HandleCommand(string message, IUser user, IRoom room)
        {
            _commandHandler.HandleCommand(message, user, room);

        }
        public IUser Authenticate(string message, TcpClient client)
        {
            return _commandHandler.Authenticate(message, client);
        }
    }
}
