using Interfaces.ControllerInterfaces;
using Interfaces.PrintingInterfaces;
using Interfaces.ReadingInterfaces;
using Interfaces.ServerInterfaces;
using Interfaces.Services.AuthenticationService;
using Interfaces.Services.RoomServices;
using System.Net.Sockets;

namespace Services.ServerServices
{
    public class ServerOperations : IServerOperations
    {
        private readonly IServer _server;
        private readonly IHandler _authenticaitonHandler;
        private readonly IPrint _print;
        private readonly IReader _reader;
        private readonly IRoomContoller _roomContoller;
        private readonly ICommandHandler _commandHandler;
        public ServerOperations(IServer server, IPrint print, IHandler handler, IReader reader,
            IRoomContoller roomOperations, ICommandHandler commandHandler)
        {
            _server = server;
            _print = print;
            _reader = reader;
            _authenticaitonHandler = handler;
            _roomContoller = roomOperations;
            _commandHandler = commandHandler;
        }
        public TcpListener Listener()
        {
            TcpListener serverSocket = new TcpListener(_server.IP, _server.Port);
            serverSocket.Start();
            Console.WriteLine($"Server waiting for clients on: {_server.IP}:{_server.Port}");
            return serverSocket;
        }
        public void HandleClientComm(object client)
        {
            TcpClient clientSocket = (TcpClient)client;
            _print.SendWelcomeMessage(clientSocket);
            try
            {
                while (clientSocket.Connected)
                {
                    string message = _reader.ReadMessage(clientSocket);
                    var authanticatedUser = _authenticaitonHandler.HandleClient(message, clientSocket);
                    _print.Commands(clientSocket);
                    string command = _reader.ReadMessage(clientSocket);
                    var room = _roomContoller.Handler(clientSocket, authanticatedUser, command);
                    _print.SendMessage(clientSocket, room.Name.ToString());
                    while (authanticatedUser.Client.Connected)
                    {
                        _print.SendMessage(clientSocket, "Type message for everyone.Type /commands to see all commands");
                        string messageForAll = _reader.ReadMessage(clientSocket);
                        _roomContoller.AddMessageToHistory(authanticatedUser, messageForAll, room);
                        _commandHandler.HandleCommand(messageForAll, authanticatedUser, room);
                    }
                    authanticatedUser.Client.Close();
                }
                clientSocket.Close();
            }
            catch (Exception)
            {
                RemoveClient(clientSocket);
            }
        }
        private void RemoveClient(TcpClient client)
        {
            _server.Clients.Remove(client);
        }
    }
}
