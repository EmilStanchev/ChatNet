using Interfaces.UserInterfaces;
using System.Net;
using System.Net.Sockets;

namespace Interfaces.ServerInterfaces
{
    public interface IServer
    {
        public IPAddress IP { get; set; }
        public int Port { get; set; }
        public List<TcpClient> Clients { get; set; }
        public List<IUser> Users { get; set; }
        public List<IRoom> Rooms { get; set; }


    }
}
