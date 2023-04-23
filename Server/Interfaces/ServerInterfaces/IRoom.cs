using Interfaces.UserInterfaces;

namespace Interfaces.ServerInterfaces
{
    public interface IRoom
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Password { get; set; }
        public List<IUser> Users { get; set; }
        public List<IMessage> History { get; set; }


    }
}
