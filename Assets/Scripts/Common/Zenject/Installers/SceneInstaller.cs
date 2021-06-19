using System;
using Common.GameStateModule;
using Common.GameStateModule.Enums;
using Common.InstallationModule;
using Zenject;

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
            gameBootstrap.RunCompleted += GameBootstrapOnRunCompleted;
            gameBootstrap.Run();
        }

        private void GameBootstrapOnRunCompleted(object sender, EventArgs e)
        {
            var gameStateMachine = Container.Resolve<IGameStateMachine>();
            gameStateMachine.SetState(ApplicationState.Battle);
        }
    }
}