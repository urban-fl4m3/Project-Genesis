using System.Collections;
using Common.GameStateModule.States;
using Common.StateModule.States;
using Common.SyncThreadModule;
using UnityEngine;

namespace Common.GameModule.Battle.SubStates
{
    public class TimerSubsSate : IState
    {
        protected virtual int _duration => 1;
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
            _game.PreparationTime.Value = _duration;
            _timer = _syncProcessor.StartSyncProcess(TimerRoutine());
        }

        public virtual void Exit()
        {
            StopTimer();
        }

        protected virtual void OnTimerFinish()
        {
            
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
            var estimatedTime = _duration;

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