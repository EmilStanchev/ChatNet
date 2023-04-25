using Interfaces.ControllerInterfaces;
using Interfaces.ServerInterfaces;
using System.Net.Sockets;

namespace Controllers
{
    public class ServerContoller : IServerContoller
    {
        private readonly IServerOperations _service;
        public ServerContoller(IServerOperations service)
        {
            _service = service;
        }

        public void Start()
        {
            TcpListener serverSocket = _service.Listener();
            while (true)
            {
                TcpClient clientSocket = serverSocket.AcceptTcpClient();
                Console.WriteLine($"Client connected: {clientSocket.Client.RemoteEndPoint}");
                Thread clientThread = new Thread(_service.HandleClient);
                clientThread.Start(clientSocket);
            }
        }
    }
}
