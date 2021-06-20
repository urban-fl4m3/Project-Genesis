using System.Collections.Generic;
using Common.GameModule.Battle.Enums;
using Common.GameModule.Battle.SubStates;
using Common.GameModule.Configs;
using Common.GameModule.Enums;
using Common.Generics;
using Common.StateModule.States;
using Common.SyncThreadModule;
using Common.UI.Enums;
using Common.UI.Managers;
using Common.UI.Views.BattleHud;

namespace Common.GameModule.Battle
{
    public class GameConcreteState : IConcreteState<ApplicationState>
    {
        private readonly IViewManager _viewManager;
        public ApplicationState State => ApplicationState.Battle;

        public readonly DynamicProperty<int> PreparationTime = new DynamicProperty<int>();
        public readonly DynamicProperty<int> Round = new DynamicProperty<int>();
        public readonly DynamicProperty<int> Coins = new DynamicProperty<int>();
        
        private readonly IReadOnlyDictionary<BattleMode, IState> _subStates;
        private readonly DynamicProperty<BattleMode> _currentBattleMode = new DynamicProperty<BattleMode>();
        
        public GameConcreteState(ISyncProcessor syncProcessor, IGameDataProvider gameDataProvider, IViewManager viewManager)
        {
            _viewManager = viewManager;
            _subStates = new Dictionary<BattleMode, IState>
            {
                { BattleMode.Preparation, new PreparationSubState(this, syncProcessor, gameDataProvider) },
                { BattleMode.Battle, new BattleSubState(this, syncProcessor) }
            };
        }
        
        public void Enter()
        {
            var hudModel = new BattleHudViewModel(PreparationTime, Round, Coins, _currentBattleMode);

            _viewManager.AddView(Window.BattleHud, hudModel);
            EnterState(BattleMode.Preparation);
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