using Interfaces.ServerInterfaces;
using Interfaces.UserInterfaces;
using System.Net.Sockets;

namespace Interfaces.ControllerInterfaces
{
    public interface IRoomContoller
    {
        public IRoom Handler(TcpClient client, IUser user, string message);
        public void AddMessageToHistory(IUser user, string message, IRoom room);
        public void HandleCommand(string message, IUser user, IRoom room);
        public IUser Authenticate(string message, TcpClient client);
    }
}
