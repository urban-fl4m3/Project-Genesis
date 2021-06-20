using System.Collections.Generic;
using System.Linq;
using Common.GameModule.Enums;
using Common.GameModule.Exceptions;
using Common.StateModule.States;

namespace Common.StateModule
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly Dictionary<ApplicationState, IConcreteState<ApplicationState>> _states;
        
        private ApplicationState _applicationState = ApplicationState.Unknown;
        private IConcreteState<ApplicationState> _currentConcreteState;
        
        public GameStateMachine(IEnumerable<IConcreteState<ApplicationState>> gameStates)
        {
            _states = gameStates.ToDictionary(x => x.State, x => x);
        }

        public void SetState(ApplicationState state)
        {
            if (state == _applicationState)
            {
                return;
            }

            if (!_states.TryGetValue(state, out var gameState))
            {
                throw new GameStateNullReference($"Game State Machine doesn't contain a {state} state");
            }

            if (_currentConcreteState != null)
            {
                _currentConcreteState.Exit();
            }

            _currentConcreteState = gameState;
            _currentConcreteState.Enter();
        }
    }
}