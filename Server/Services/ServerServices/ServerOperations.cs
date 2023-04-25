using Interfaces.ControllerInterfaces;
using Interfaces.PrintingInterfaces;
using Interfaces.ReadingInterfaces;
using Interfaces.ServerInterfaces;
using Interfaces.Services.RoomServices;
using Interfaces.UserInterfaces;
using System.Net.Sockets;

namespace Services.ServerServices
{
    public class ServerOperations : IServerOperations
    {
        private readonly IServer _server;
        private readonly IPrint _print;
        private readonly IReader _reader;
        private readonly IRoomContoller _roomContoller;
        private readonly ICommandHandler _commandHandler;
        public ServerOperations(IServer server, IPrint print, IReader reader,
            IRoomContoller roomOperations, ICommandHandler commandHandler)
        {
            _server = server;
            _print = print;
            _reader = reader;
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
        public void HandleClient(object client)
        {
            TcpClient clientSocket = (TcpClient)client;
            _print.SendWelcomeMessage(clientSocket);
            try
            {
                while (clientSocket.Connected)
                {
                    HandleRegistration(clientSocket);
                }
                clientSocket.Close();
            }
            catch (Exception)
            {
                RemoveClient(clientSocket);
            }
        }
        private void HandleRegistration(TcpClient client)
        {
            string message = _reader.ReadMessage(client);
            var authanticatedUser = _commandHandler.Authenticate(message, client);
            _print.Commands(client);
            string command = _reader.ReadMessage(client);
            var room = _roomContoller.Handler(client, authanticatedUser, command);
            _print.SendMessage(client, room.Name.ToString());
            while (authanticatedUser.Client.Connected)
            {
                HandleCommand(authanticatedUser, room);
            }
            authanticatedUser.Client.Close();
        }
        private void HandleCommand(IUser user, IRoom room)
        {
            _print.SendMessage(user.Client, "Type message for everyone.Type /commands to see all commands");
            string messageForAll = _reader.ReadMessage(user.Client);
            _roomContoller.AddMessageToHistory(user, messageForAll, room);
            _commandHandler.HandleCommand(messageForAll, user, room);
        }
        private void RemoveClient(TcpClient client)
        {
            _server.Clients.Remove(client);
        }
    }
}
