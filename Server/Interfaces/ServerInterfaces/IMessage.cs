using Interfaces.UserInterfaces;

namespace Interfaces.ServerInterfaces
{
    public interface IMessage
    {
        public string Id { get; set; }
        public IUser Sender { get; set; }
        public string Content { get; set; }
        public DateTime SendAt { get; set; }

    }
}
