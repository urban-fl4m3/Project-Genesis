using Common.GameStateModule.States.Battle.Enums;
using Common.SyncThreadModule;

namespace Common.GameStateModule.States.Battle.SubStates
{
    public class PreparationSubState : TimerSubsSate
    {
        protected override int _duration => 10;
        
        public PreparationSubState(GameConcreteState game, ISyncProcessor syncProcessor) : base(game, syncProcessor)
        {
            
        }

        protected override void OnTimerFinish()
        {
            _game.ChangeSubState(BattleMode.Battle);
        }
    }
}