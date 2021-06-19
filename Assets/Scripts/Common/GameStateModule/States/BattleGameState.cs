using System;
using Common.GameStateModule.Enums;
using Common.GameStateModule.States.Base;
using Common.Generics;
using Common.Logger;
using Common.UI.Base;
using Common.UI.Configurations;
using Common.UI.Enums;
using Common.UI.Views.BattleHud;
using Object = UnityEngine.Object;

namespace Common.GameStateModule.States
{
    public class BattleGameState : IGameState
    {
        private readonly ILogger _logger;
        private readonly IViewProvider _viewProvider;
        public GameStateId StateId => GameStateId.Battle;

        public BattleGameState(ILogger logger, IViewProvider viewProvider)
        {
            _logger = logger;
            _viewProvider = viewProvider;
        }
        
        public void Enter()
        {
            _logger.Log($"{nameof(BattleGameState)}", "Entering state...");
            
            var windowInfrastructure = _viewProvider.GetWindowInfrastructure(Window.BattleHud);
            var canvas = Object.Instantiate(windowInfrastructure.Item1);
            var window = Object.Instantiate(windowInfrastructure.Item2, canvas.transform);
            
            var view = window.GetComponent<IView>();
            var preparationTime = 60;
            view.Activate(new BattleHudViewModel(
                preparationTime,
                new DynamicProperty<int>(1),
                new DynamicProperty<int>(10)));

            var timeSpan = TimeSpan.FromSeconds(preparationTime);
        }

        public void Exit()
        {
            
        }
    }
}