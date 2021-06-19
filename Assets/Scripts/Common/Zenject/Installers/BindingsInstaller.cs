using Common.Zenject.Bindings;
using Zenject;

namespace Common.Zenject.Installers
{
    public class BindingsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InitializeCommandsBindings.Bind(Container);
            GameStateBindings.Bind(Container);
            StartingCommandsBindings.Bind(Container);
            UiBindings.Bind(Container);
            LogBindings.Bind(Container);
        }
    }
}