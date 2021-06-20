using Common.GameModule.Battle.Enums;
using Common.GameModule.Configs;
using Common.SyncThreadModule;

namespace Common.GameModule.Battle.SubStates
{
    public class PreparationSubState : TimerSubsSate
    {
        private readonly IGameDataProvider _gameDataProvider;
        
        public PreparationSubState(GameConcreteState game, ISyncProcessor syncProcessor, IGameDataProvider
            gameDataProvider) : base(game, syncProcessor)
        {
            _gameDataProvider = gameDataProvider;
        }

        public override void Enter()
        {
            _game.Coins.Value += _gameDataProvider.StartingGold + _game.Round.Value * _gameDataProvider.MoneyMultiplier;
            _game.Round.Value++;
            
            base.Enter();
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