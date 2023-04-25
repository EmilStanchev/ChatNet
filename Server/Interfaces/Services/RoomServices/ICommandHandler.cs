using Interfaces.ServerInterfaces;
using Interfaces.UserInterfaces;
using System.Net.Sockets;

namespace Interfaces.Services.RoomServices
{
    public interface ICommandHandler
    {
        public void HandleCommand(string message, IUser user, IRoom room);
        public IUser Authenticate(string message, TcpClient client);
    }
}
