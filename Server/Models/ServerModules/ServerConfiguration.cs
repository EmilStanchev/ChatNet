using Interfaces.PrintingInterfaces;
using Interfaces.ReadingInterfaces;
using Interfaces.ServerInterfaces;

namespace Models.ServerModules
{
    public class ServerConfiguration : IServerConfiguration
    {
        public IServer Server { get; set; }
        public IPrint Print { get; set; }
        public IReader Reader { get; set; }
        public ServerConfiguration(IServer server, IPrint print, IReader reader)
        {
            Server = server;
            Print = print;
            Reader = reader;
        }
    }
}
