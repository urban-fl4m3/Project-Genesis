using System.Collections.Generic;
using Common.CameraModule;
using Common.GameModule.Battle.Enums;
using Common.GameModule.Battle.SubStates;
using Common.GameModule.Configs;
using Common.GameModule.Enums;
using Common.Generics;
using Common.StateModule.States;
using Common.StateModule.States.Abstract;
using Common.SyncThreadModule;
using Common.TickModule;
using Common.UI.Actions;
using Common.UI.Enums;
using Common.UI.Managers;
using Common.UI.Views.BattleBottomHud;
using Common.UI.Views.BattleShop;
using Common.UI.Views.BattleUpperHud;
using UnityEngine;

namespace Common.GameModule.Battle
{
    public class GameState : ViewState<ApplicationState>
    {
        public override ApplicationState State => ApplicationState.Battle;
        
        public readonly DynamicProperty<int> PreparationTime = new DynamicProperty<int>();
        public readonly DynamicProperty<int> Round = new DynamicProperty<int>();
        public readonly DynamicProperty<int> Coins = new DynamicProperty<int>();

        private readonly ITickManager _tickManager;
        private readonly ICameraManager _cameraManager;
        private readonly ISyncProcessor _syncProcessor;
        private readonly IGameDataProvider _gameDataProvider;
        private readonly DynamicProperty<BattleMode> _currentBattleMode = new DynamicProperty<BattleMode>();
        
        private IReadOnlyDictionary<BattleMode, IState> _subStates;
        
        public GameState(ISyncProcessor syncProcessor, IGameDataProvider gameDataProvider, IViewManager viewManager,
            ITickManager tickManager, ICameraManager cameraManager) :base(viewManager)
        {
            _syncProcessor = syncProcessor;
            _gameDataProvider = gameDataProvider;
            _tickManager = tickManager;
            _cameraManager = cameraManager;
        }
        
        public override void Enter()
        {
            base.Enter();
            
            var field = Object.Instantiate(_gameDataProvider.GetBattleField());
            field.Activate();
            
            _subStates = new Dictionary<BattleMode, IState>
            {
                { BattleMode.Preparation, new PreparationSubState(this, _syncProcessor, _gameDataProvider, _tickManager,
                    field, _cameraManager) },
                { BattleMode.Battle, new BattleSubState(this, _syncProcessor) }
            };

            
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