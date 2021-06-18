using System;
using Common.Generics;
using Common.UI.Configurations;
using Common.UI.Enums;
using Common.UI.Views.BattleHud;
using ILogger = Common.Logger.ILogger;
using Object = UnityEngine.Object;

namespace Common.InstallationModule
{
    public class GameBootstrap : IGameBootstrap
    {
        private readonly ILogger _logger;
        private readonly IViewProvider _viewProvider;

        public GameBootstrap(ILogger logger, IViewProvider viewProvider)
        {
            _logger = logger;
            _viewProvider = viewProvider;
        }
        
        public void Run()
        {
            _logger.Log("Installation Module", "Bootstrap start running...");
            var windowInfrastructure = _viewProvider.GetWindowInfrastructure(Window.BattleHud);
            var canvas = Object.Instantiate(windowInfrastructure.Item1);
            var window = Object.Instantiate(windowInfrastructure.Item2, canvas.transform);
            
            var view = window.GetComponent<BattleHudView>();
            var preparationTime = 60;
            view.Activate(new BattleHudViewModel(
                preparationTime,
                new DynamicProperty<int>(1),
                new DynamicProperty<int>(10)));

            // var timeSpan = TimeSpan.FromSeconds(preparationTime);
        }
    }
}