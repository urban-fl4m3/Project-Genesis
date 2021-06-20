using Common.Zenject.Bindings;
using Zenject;

namespace Common.Zenject.Installers
{
    public class BindingsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            TickBindings.Bind(Container);
            SyncThreadBindings.Bind(Container);
            CameraBindings.Bind(Container);
            GameBindings.Bind(Container);
            InitializeCommandsBindings.Bind(Container);
            StateBindings.Bind(Container);
            UiBindings.Bind(Container);
            LogBindings.Bind(Container);
        }
    }
}