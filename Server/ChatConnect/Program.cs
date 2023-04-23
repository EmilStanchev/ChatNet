
using ChatConnect.NugetConfiguration;
using Interfaces.ControllerInterfaces;
using Ninject;

var kernel = new StandardKernel(new ChatModule());
var chat = kernel.Get<IServerContoller>();
chat.Start();