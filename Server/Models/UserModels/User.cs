using Interfaces.ServerInterfaces;
using Interfaces.UserInterfaces;
using System.Net;
using System.Net.Sockets;

namespace Models.UserModels
{
    public class User : IUser
    {
        public User(IPAddress ip, string username, string password, TcpClient client)
        {
            IP = ip;
            Username = username;
            Password = password;
            CreatedAt = DateTime.Now;
            Client = client;
        }
        public IPAddress IP { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public TcpClient Client { get; set; }
        public List<IRoom> Rooms { get; set; } = new List<IRoom>();

        public DateTime CreatedAt { get; set; }
    }
}
