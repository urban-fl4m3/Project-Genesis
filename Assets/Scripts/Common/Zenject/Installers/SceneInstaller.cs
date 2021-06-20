using System;
using Common.ActorModule;
using Common.CameraModule;
using Common.GameModule.Enums;
using Common.InstallationModule;
using Common.StateModule;
using UnityEngine;
using Zenject;

namespace Common.Zenject.Installers
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private Actor _cameraActor;
        
        public override void InstallBindings()
        {
            Container
                .Bind<IGameBootstrap>()
                .To<GameBootstrap>()
                .AsSingle();
        }
        
        public override void Start()
        {
            var cameraManager = Container.Resolve<ICameraManager>();
            cameraManager.SetGameCamera(_cameraActor);
            
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