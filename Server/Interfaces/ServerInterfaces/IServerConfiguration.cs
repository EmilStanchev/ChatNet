using Interfaces.PrintingInterfaces;
using Interfaces.ReadingInterfaces;

namespace Interfaces.ServerInterfaces
{
    public interface IServerConfiguration
    {
        public IServer Server { get; set; }
        public IPrint Print { get; set; }
        public IReader Reader { get; set; }
    }
}
