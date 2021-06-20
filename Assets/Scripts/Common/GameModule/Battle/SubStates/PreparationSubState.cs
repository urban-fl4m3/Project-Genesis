using Common.ActorModule.Components;
using Common.ActorModule.Components.Concrete;
using Common.CameraModule;
using Common.GameModule.Battle.Enums;
using Common.GameModule.Battle.Ticks;
using Common.GameModule.Configs;
using Common.Generics;
using Common.SyncThreadModule;
using Common.TickModule;
using UnityEngine;

namespace Common.GameModule.Battle.SubStates
{
    public class PreparationSubState : TimerSubsSate
    {
        private readonly IGameDataProvider _gameDataProvider;
        private readonly ITickManager _tickManager;

        private readonly DynamicProperty<IActor> _selectedActor = new DynamicProperty<IActor>();
        private readonly ITickUpdate _battleDragUnitTick;
        private readonly BattleSideComponent _sideComponent;
        
        public PreparationSubState(GameState game, ISyncProcessor syncProcessor, IGameDataProvider gameDataProvider,
            ITickManager tickManager, IActor ground, ICameraManager cameraManager) : base(game, syncProcessor)
        {
            _gameDataProvider = gameDataProvider;
            _tickManager = tickManager;
            _sideComponent = ground.GetActorComponent<BattleSideComponent>();
            _battleDragUnitTick = new BattleDragUnitTick(_selectedActor, cameraManager.GameCamera, _sideComponent);
        }

        protected override void OnEnter()
        {
            _sideComponent.EnemySide.SetActive(true);
            _sideComponent.PlayerSide.SetActive(true);
            
            _tickManager.AddTick(this, _battleDragUnitTick);
            
            _game.Coins.Value += _gameDataProvider.StartingGold + _game.Round.Value * _gameDataProvider.MoneyMultiplier;
            _game.Round.Value++;
            
            if (_selectedActor.Value == null)
            {
                var sphereMage = Object.Instantiate(_gameDataProvider.GetUnitData()[0].Actor);
                sphereMage.Activate();
                _selectedActor.Value = sphereMage;
            }

        }

        protected override void OnExit()
        {
            _sideComponent.EnemySide.SetActive(false);
            _sideComponent.PlayerSide.SetActive(false);
            
            _tickManager.RemoveTick(_battleDragUnitTick);
        }

        protected override void OnTimerFinish()
        {
            _game.ChangeSubState(BattleMode.Battle);
        }

        protected override int GetDurationTime()
        {
            return _gameDataProvider.PreparationTime;
        }
    }
}