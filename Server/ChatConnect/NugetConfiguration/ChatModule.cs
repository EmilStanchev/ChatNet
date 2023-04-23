using Controllers;
using Interfaces.AuthenticationService;
using Interfaces.ControllerInterfaces;
using Interfaces.Factories;
using Interfaces.PrintingInterfaces;
using Interfaces.ReadingInterfaces;
using Interfaces.ServerInterfaces;
using Interfaces.Services.AuthenticationService;
using Interfaces.Services.RoomServices;
using Interfaces.UserInterfaces;
using Models.PrintModels;
using Models.ReadingModels;
using Models.ServerModules;
using Models.UserModels;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using Services.AuthenticationServices;
using Services.RoomServices;
using Services.ServerServices;

namespace ChatConnect.NugetConfiguration
{
    public class ChatModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPrint>().To<Print>();
            Bind<IReader>().To<Reader>();
            Bind<IServer>().To<Server>().InSingletonScope();
            Bind<IRoom>().To<Room>();
            Bind<IUser>().To<User>();
            Bind<IMessage>().To<Message>();
            Bind<IRoomOperations>().To<RoomOperations>();
            Bind<ILoginService>().To<LoginService>();
            Bind<IRegisterService>().To<RegisterService>();
            Bind<IRoomContoller>().To<RoomController>();
            Bind<ICommandHandler>().To<CommandHandler>();
            Bind<IServerOperations>().To<ServerOperations>();
            Bind<IServerContoller>().To<ServerContoller>();
            Bind<IHandler>().To<Handler>();
            Bind<IUserFactory>().ToFactory();
            Bind<IRoomFactory>().ToFactory();
            Bind<IMessageFactory>().ToFactory();

        }
    }
}
