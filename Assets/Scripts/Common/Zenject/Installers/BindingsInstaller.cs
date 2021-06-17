using Common.Zenject.Bindings;
using Zenject;

namespace Common.Zenject.Installers
{
    public class BindingsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            StartingCommandsBindings.Bind(Container);
            LogBindings.Bind(Container);
        }
    }
}