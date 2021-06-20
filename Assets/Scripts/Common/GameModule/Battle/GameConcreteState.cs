using System.Collections.Generic;
using Common.GameModule.Battle.Enums;
using Common.GameModule.Battle.SubStates;
using Common.GameModule.Configs;
using Common.GameModule.Enums;
using Common.Generics;
using Common.StateModule.States;
using Common.StateModule.States.Abstract;
using Common.SyncThreadModule;
using Common.UI.Actions;
using Common.UI.Enums;
using Common.UI.Managers;
using Common.UI.Views.BattleBottomHud;
using Common.UI.Views.BattleShop;
using Common.UI.Views.BattleUpperHud;

namespace Common.GameModule.Battle
{
    public class GameConcreteState : ViewState<ApplicationState>
    {
        public override ApplicationState State => ApplicationState.Battle;
        

        public readonly DynamicProperty<int> PreparationTime = new DynamicProperty<int>();
        public readonly DynamicProperty<int> Round = new DynamicProperty<int>();
        public readonly DynamicProperty<int> Coins = new DynamicProperty<int>();
        
        private readonly IReadOnlyDictionary<BattleMode, IState> _subStates;
        private readonly DynamicProperty<BattleMode> _currentBattleMode = new DynamicProperty<BattleMode>();
        
        public GameConcreteState(ISyncProcessor syncProcessor, IGameDataProvider gameDataProvider, IViewManager viewManager)
         :base(viewManager)
        {
            _subStates = new Dictionary<BattleMode, IState>
            {
                { BattleMode.Preparation, new PreparationSubState(this, syncProcessor, gameDataProvider) },
                { BattleMode.Battle, new BattleSubState(this, syncProcessor) }
            };
        }
        
        public override void Enter()
        {
            base.Enter();
            
            AddView(Window.BattleUpperHud, new BattleUpperHudViewModel(PreparationTime, Round, Coins, _currentBattleMode));
            AddView(Window.BattleBottomHud, new BattleBottomHudViewModel());
            
            EnterState(BattleMode.Preparation);
        }

        public override void Exit()
        {
            base.Exit();
            
            ExitCurrentState();
        }

        protected override void OnBindAction(IActionBinder actionContainer)
        {
            actionContainer.Bind("open_shop", context =>
            {
                AddView(Window.BattleShop, new BattleShopViewModel());
            });
            
            actionContainer.Bind("close_shop", context =>
            {
                CloseView(Window.BattleShop);
            });
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
    }
}