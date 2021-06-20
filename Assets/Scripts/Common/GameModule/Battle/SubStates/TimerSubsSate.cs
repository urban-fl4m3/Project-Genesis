using System.Collections;
using Common.StateModule.States;
using Common.SyncThreadModule;
using UnityEngine;

namespace Common.GameModule.Battle.SubStates
{
    public class TimerSubsSate : IState
    {
        protected readonly GameConcreteState _game;
        
        private readonly ISyncProcessor _syncProcessor;
        private readonly WaitForSeconds _waitForSeconds = new WaitForSeconds(1);
            
        private Coroutine _timer;


        protected TimerSubsSate(GameConcreteState game, ISyncProcessor syncProcessor)
        {
            _game = game;
            _syncProcessor = syncProcessor;
        }
        
        public virtual void Enter()
        {
            _game.PreparationTime.Value = GetDurationTime();
            _timer = _syncProcessor.StartSyncProcess(TimerRoutine());
        }

        public virtual void Exit()
        {
            StopTimer();
        }

        protected virtual void OnTimerFinish()
        {
            
        }
        
        protected virtual int GetDurationTime()
        {
            return 1;
        }

        protected void StopTimer()
        {
            if (_timer == null)
            {
                return;
            }
            
            _syncProcessor.StopSyncProcess(_timer);
            _timer = null;
        }
        
        private IEnumerator TimerRoutine()
        {
            var estimatedTime = GetDurationTime();

            while (estimatedTime > 0)
            {
                _game.PreparationTime.Value = estimatedTime;
                yield return _waitForSeconds;
                estimatedTime--;
            }
            
            StopTimer();
            OnTimerFinish();
        }
    }
}