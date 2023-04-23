using Interfaces.ReadingInterfaces;
using System.Net.Sockets;

namespace Models.ReadingModels
{
    public class Reader : IReader
    {
        public string ReadMessage(TcpClient client)
        {
            StreamReader reader = new StreamReader(client.GetStream());
            string message = reader.ReadLine();
            while (string.IsNullOrWhiteSpace(message))
            {
                message = reader.ReadLine();
            }
            return message.ToLower();
        }
    }
}
