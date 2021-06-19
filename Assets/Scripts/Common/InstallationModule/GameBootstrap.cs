using System;
using Common.Commands;
using Common.Generics;
using Common.InstallationModule.InitializeCommands;
using Common.UI.Base;
using Common.UI.Configurations;
using Common.UI.Enums;
using Common.UI.Views.BattleHud;
using ILogger = Common.Logger.ILogger;
using Object = UnityEngine.Object;

namespace Common.InstallationModule
{
    public class GameBootstrap : IGameBootstrap
    {
        private readonly LoggerInitializeCommand _loggerInitializeCommand;
        private readonly ILogger _logger;
        private readonly IViewProvider _viewProvider;

        private readonly ICommandQueue _initializer = new CommandQueue();

        public GameBootstrap(LoggerInitializeCommand loggerInitializeCommand)
        {
            _loggerInitializeCommand = loggerInitializeCommand;
        }
        
        public void Run()
        {
            _initializer.Add(_loggerInitializeCommand);
            
            _initializer.OnComplete += InitializerOnOnComplete;
            _initializer.ExecuteAll();
            
            // var windowInfrastructure = _viewProvider.GetWindowInfrastructure(Window.BattleHud);
            // var canvas = Object.Instantiate(windowInfrastructure.Item1);
            // var window = Object.Instantiate(windowInfrastructure.Item2, canvas.transform);
            //
            // var view = window.GetComponent<IView>();
            // var preparationTime = 60;
            // view.Activate(new BattleHudViewModel(
            //     preparationTime,
            //     new DynamicProperty<int>(1),
            //     new DynamicProperty<int>(10)));

            // var timeSpan = TimeSpan.FromSeconds(preparationTime);
        }

        private void InitializerOnOnComplete(object sender, EventArgs e)
        {
            
        }
    }
}