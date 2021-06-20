using System;
using System.Collections.Generic;
using Common.GameModule.Battle.Enums;
using Common.GameModule.Battle.SubStates;
using Common.GameModule.Configs;
using Common.GameModule.Enums;
using Common.GameStateModule.States;
using Common.Generics;
using Common.Logger;
using Common.StateModule.States;
using Common.SyncThreadModule;
using Common.UI.Base;
using Common.UI.Configurations;
using Common.UI.Enums;
using Common.UI.Views.BattleHud;
using Object = UnityEngine.Object;

namespace Common.GameModule.Battle
{
    public class GameConcreteState : IConcreteState<ApplicationState>
    {
        public ApplicationState State => ApplicationState.Battle;

        public readonly DynamicProperty<int> PreparationTime = new DynamicProperty<int>();
        public readonly DynamicProperty<int> Round = new DynamicProperty<int>();
        public readonly DynamicProperty<int> Coins = new DynamicProperty<int>();
        
        private readonly ILogger _logger;
        private readonly IViewProvider _viewProvider;
        private readonly IReadOnlyDictionary<BattleMode, IState> _subStates;
        private readonly DynamicProperty<BattleMode> _currentBattleMode = new DynamicProperty<BattleMode>();
        
        public GameConcreteState(ILogger logger, ISyncProcessor syncProcessor, IViewProvider viewProvider,
            IGameDataProvider gameDataProvider)
        {
            _logger = logger;
            _viewProvider = viewProvider;

            _subStates = new Dictionary<BattleMode, IState>
            {
                { BattleMode.Preparation, new PreparationSubState(this, syncProcessor, gameDataProvider) },
                { BattleMode.Battle, new BattleSubState(this, syncProcessor) }
            };
        }
        
        public void Enter()
        {
            _logger.Log($"{nameof(GameConcreteState)}", "Entering state...");
            var hudModel = new BattleHudViewModel(PreparationTime, Round, Coins, _currentBattleMode);

            CreateView(Window.BattleHud, hudModel);
            EnterState(BattleMode.Preparation);
        }

        //Temporary solution. Later i will add factory for views.
        private void CreateView(Window type, IViewModel model)
        {
            var (rawCanvas, rawWindow) = _viewProvider.GetWindowInfrastructure(type);
            var canvas = Object.Instantiate(rawCanvas);
            var window = Object.Instantiate(rawWindow, canvas.transform);
            var view = window.GetComponent<IView>();
            view.Activate(model);
        }

        public void ChangeSubState(BattleMode state)
        {
            ExitCurrentState();
            EnterState(state);
        }

        private void ExitCurrentState()
        {
            _subStates[_currentBattleMode.Value].Exit();
        }

        private void EnterState(BattleMode state)
        {
            _subStates[state].Enter();
            _currentBattleMode.Value = state;
        }

        public void Exit()
        {
            ExitCurrentState();
        }
    }
}