using Interfaces.ControllerInterfaces;
using Interfaces.ServerInterfaces;
using Interfaces.Services.RoomServices;
using Interfaces.UserInterfaces;
using System.Net.Sockets;

namespace Controllers
{
    public class RoomController : IRoomContoller
    {
        private readonly IRoomOperations _roomService;
        public RoomController(IRoomOperations roomService)
        {
            _roomService = roomService;
        }
        public IRoom Handler(TcpClient client, IUser user, string message)
        {
            switch (message)
            {
                case "/create":
                case "create":
                    return _roomService.CreateRoom(user.Client, user);
                case "/join":
                case "join":
                    return _roomService.JoinRoom(user, user.Client);
                default:
                    _roomService.InvalidCommand(user.Client);
                    return null;
            }
        }
        public void AddMessageToHistory(IUser user, string message, IRoom room)
        {
            _roomService.AddToHistory(user, message, room);
        }

    }
}
