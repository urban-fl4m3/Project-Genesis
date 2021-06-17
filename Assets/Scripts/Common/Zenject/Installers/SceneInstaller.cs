using Common.InstallationModule;
using Zenject;
using ILogger = Common.Logger.ILogger;

namespace Common.Zenject.Installers
{
    public class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IGameBootstrap>()
                .To<GameBootstrap>()
                .AsSingle();
        }
        
        public override void Start()
        {
            var gameBootstrap = Container.Resolve<IGameBootstrap>();
            gameBootstrap.Run();
        }
    }
}