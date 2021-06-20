using Common.GameModule.Battle.Enums;
using Common.SyncThreadModule;

namespace Common.GameModule.Battle.SubStates
{
    public class PreparationSubState : TimerSubsSate
    {
        protected override int _duration => 60;
        
        public PreparationSubState(GameConcreteState game, ISyncProcessor syncProcessor) : base(game, syncProcessor)
        {
            
        }

        protected override void OnTimerFinish()
        {
            _game.ChangeSubState(BattleMode.Battle);
        }
    }
}