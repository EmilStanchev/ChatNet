using Interfaces.ServerInterfaces;
using System.Net;
using System.Net.Sockets;

namespace Interfaces.UserInterfaces
{
    public interface IUser
    {
        public IPAddress IP { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public TcpClient Client { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<IRoom> Rooms { get; set; }
    }
}
