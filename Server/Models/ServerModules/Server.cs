using Interfaces.ServerInterfaces;
using Interfaces.UserInterfaces;
using System.Net;
using System.Net.Sockets;

namespace Models.ServerModules
{
    public class Server : IServer
    {
        private readonly IPAddress _ip = IPAddress.Parse("YOUR IP");
        private readonly int _port = 8000;


        //public Server()
        //{
        //    IP = _ip;
        //    Port = _port;
        //}
        public Server(string ip, int port)
        {

        }
        public Server(IPAddress ip)
        {

        }
        public IPAddress IP { get; set; }
        public int Port { get; set; }
        public List<TcpClient> Clients { get; set; } = new List<TcpClient>();
        public List<IUser> Users { get; set; } = new List<IUser>();
        public List<IRoom> Rooms { get; set; } = new List<IRoom>();
    }
}
