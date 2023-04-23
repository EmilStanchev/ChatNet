using System.Net.Sockets;


string ipAddress = "192.168.0.102";
int port = 8000;
TcpClient client = new TcpClient(ipAddress, port);
Console.WriteLine("Connected to server: {0}", client.Client.RemoteEndPoint);
StreamReader reader = new StreamReader(client.GetStream());
StreamWriter writer = new StreamWriter(client.GetStream()) { AutoFlush = true };
new Thread(() =>
{
    while (true)
    {
        string message = reader.ReadLine();
        Console.WriteLine(message);
    }
    reader.Close();
    writer.Close();
    client.Close();
}).Start();
new Thread(() =>
{
    while (true)
    {
        string message = Console.ReadLine();
        Console.WriteLine($"Your message:{message} was sent");
        writer.WriteLine(message);
    }
}).Start();
Console.ReadKey();
