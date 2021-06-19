using Common.InstallationModule.InitializeCommands;
using Zenject;

namespace Common.Zenject.Bindings
{
    public class InitializeCommandsBindings
    {
        public static void Bind(DiContainer container)
        {
            container.Bind<LoggerInitializeCommand>().AsTransient();
        }
    }
}