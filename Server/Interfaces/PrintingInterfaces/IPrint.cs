using Interfaces.UserInterfaces;
using System.Net.Sockets;

namespace Interfaces.PrintingInterfaces
{
    public interface IPrint
    {
        public void SendMessage(TcpClient client, string message);
        public void BroadcastMessage(IUser sender, string message, List<IUser> clients);
        public void SendWelcomeMessage(TcpClient clientSocket);
        public void Commands(TcpClient clientSocket);
        public void AllCommands(IUser user);
    }
}
