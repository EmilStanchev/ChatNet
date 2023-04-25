using Interfaces.PrintingInterfaces;
using Interfaces.ReadingInterfaces;
using Interfaces.Services;
using System.Net.Sockets;

namespace Services.ServerServices
{

    public class ProcessingInput : IProcessingInput
    {
        private readonly IReader _reader;
        private readonly IPrint _print;
        public ProcessingInput(IPrint print, IReader reader)
        {
            _print = print;
            _reader = reader;
        }
        public string ReturnUserame(TcpClient client)
        {
            _print.SendMessage(client, "Enter username:");
            string username = _reader.ReadMessage(client);
            return username;
        }
        public string ReturnPassword(TcpClient client)
        {
            _print.SendMessage(client, "Enter password:");
            string password = _reader.ReadMessage(client);
            return password;
        }
        public void SuccesfullReg(TcpClient client)
        {
            _print.SendMessage(client, "Registration successful. You are now logged in.");
        }
    }
}
