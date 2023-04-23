using Interfaces.ServerInterfaces;
using Interfaces.UserInterfaces;
using System.Net.Sockets;

namespace Interfaces.Services.RoomServices
{
    public interface IRoomOperations
    {
        public IRoom CreateRoom(TcpClient client, IUser user);
        public IRoom JoinRoom(IUser user, TcpClient client);
        public void InvalidCommand(TcpClient client);
        public void AddToHistory(IUser user, string message, IRoom room);
    }
}
