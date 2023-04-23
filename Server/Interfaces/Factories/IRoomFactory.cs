using Interfaces.ServerInterfaces;

namespace Interfaces.Factories
{
    public interface IRoomFactory
    {
        public IRoom CreateRoom(string name, string password);
    }
}
