using Common.GameModule.Battle.Enums;
using Common.SyncThreadModule;

namespace Common.GameModule.Battle.SubStates
{
    public class BattleSubState : TimerSubsSate
    {
        public BattleSubState(GameState game, ISyncProcessor syncProcessor) : base(game, syncProcessor)
        {
            
        }

        protected override void OnTimerFinish()
        {
            _game.ChangeSubState(BattleMode.Preparation);
        }

        protected override int GetDurationTime()
        {
            return 5;
        }
    }
}