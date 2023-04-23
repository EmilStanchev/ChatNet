using Interfaces.PrintingInterfaces;
using Interfaces.UserInterfaces;
using System.Net.Sockets;

namespace Models.PrintModels
{
    public class Print : IPrint
    {
        public void SendMessage(TcpClient client, string message)
        {
            StreamWriter writer = new StreamWriter(client.GetStream());
            writer.WriteLine(message);
            writer.Flush();
        }
        public void BroadcastMessage(IUser sender, string message, List<IUser> users)
        {
            foreach (IUser user in users)
            {
                if (user != sender)
                {
                    SendMessage(user.Client, $"{sender.Username}: {message}");
                }
            }
        }
        public void AllCommands(IUser user)
        {
            SendMessage(user.Client, "Commands:");
            SendMessage(user.Client, "/history- to show room history");
            SendMessage(user.Client, "/quit- to log out");
            SendMessage(user.Client, "/commands- to show all commands");
            SendMessage(user.Client, "/create - to create room ");
            SendMessage(user.Client, "/join- to join room ");
            SendMessage(user.Client, "/ban NAME - to ban person from room with specific name");

        }
        public void SendWelcomeMessage(TcpClient clientSocket)
        {
            SendMessage(clientSocket, "Welcome to the chat server. " +
                "Type /register for registet and /login for login.");
        }
        public void Commands(TcpClient clientSocket)
        {
            SendMessage(clientSocket, "Commands:");
            SendMessage(clientSocket, "/join for joining in room");
            SendMessage(clientSocket, "/create for creating room");
        }
    }
}
