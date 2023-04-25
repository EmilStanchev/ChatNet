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
        private readonly IReader _reader;
        public RoomController(IRoomOperations roomService, IReader reader)
        {
            _roomService = roomService;
            _reader = reader;
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

    }
}
