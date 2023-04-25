using Interfaces.Factories;
using Interfaces.PrintingInterfaces;
using Interfaces.ReadingInterfaces;
using Interfaces.ServerInterfaces;
using Interfaces.Services.RoomServices;
using Interfaces.UserInterfaces;
using System.Net.Sockets;

namespace Services.RoomServices
{
    public class RoomOperations : IRoomOperations
    {
        private readonly IReader _reader;
        private readonly IPrint _print;
        private readonly IServerFactory _serverFactory;
        private readonly IServer _server;
        public RoomOperations(IPrint print, IReader reader, IServer server, IServerFactory serverFactory)
        {
            _reader = reader;
            _print = print;
            _serverFactory = serverFactory;
            _server = server;
        }
        public IRoom CreateRoom(TcpClient client, IUser user)
        {
            _print.SendMessage(client, "Enter the name for the room:");
            string roomName = _reader.ReadMessage(client);
            _print.SendMessage(client, "Enter the password for the room (leave blank if there is no password):");
            string password = _reader.ReadMessage(client);
            while (IsRoomNameTaken(roomName))
            {
                _print.SendMessage(client, "There is already a room with this name.");
                roomName = _reader.ReadMessage(client);
            }
            var room = _serverFactory.CreateRoom(roomName, password);
            room.Users.Add(user);
            user.Rooms.Add(room);
            _print.SendMessage(client, $"Room {roomName} created.");
            _server.Rooms.Add(room);
            return room;
        }
        public IRoom JoinRoom(IUser user, TcpClient client)
        {
            _print.SendMessage(client, "Enter name for the room");
            string name = _reader.ReadMessage(client);
            _print.SendMessage(client, "Enter the password for the room (leave blank if there is no password):");
            string password = _reader.ReadMessage(client);
            while (true)
            {
                var room = _server.Rooms.FirstOrDefault(r => r.Name == name && r.Password == password);
                if (room != null)
                {
                    room.Users.Add(user);
                    user.Rooms.Add(room);
                    _print.SendMessage(user.Client, $"You joined in {room.Name}");
                    _print.BroadcastMessage(user, $"{user.Username} joined in the {room.Name}", room.Users);
                    _print.SendMessage(client, "Type your messages below. Press Enter to send.");
                    return room;
                }
                else
                {
                    _print.SendMessage(client, "Invalid password or name.");
                    _print.SendMessage(client, "Enter name for the room");
                    name = _reader.ReadMessage(client);
                    _print.SendMessage(client, "Enter the password for the room " +
                        "(leave blank if there is no password):");
                    password = _reader.ReadMessage(client);
                }
            }
        }
        public void AddToHistory(IUser user, string message, IRoom room)
        {
            IMessage newMessage = _serverFactory.CreateMessage(user, message);
            room.History.Add(newMessage);
        }
        public void InvalidCommand(TcpClient client)
        {
            _print.SendMessage(client, "invalid command");
        }
        private bool IsRoomNameTaken(string roomName)
        {
            return _server.Rooms.Any(r => r.Name == roomName);
        }
    }
}
