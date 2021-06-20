using Common.GameModule.Battle.Enums;
using Common.SyncThreadModule;

namespace Common.GameModule.Battle.SubStates
{
    public class BattleSubState : TimerSubsSate
    {
        protected override int _duration => 5;
        
        public BattleSubState(GameConcreteState game, ISyncProcessor syncProcessor) : base(game, syncProcessor)
        {
            
        }

        protected override void OnTimerFinish()
        {
            _game.ChangeSubState(BattleMode.Preparation);
        }

        public override void Exit()
        {
            base.Exit();
            
            _game.Coins.Value = 5 + _game.Round.Value;
            _game.Round.Value++;
        }
    }
}