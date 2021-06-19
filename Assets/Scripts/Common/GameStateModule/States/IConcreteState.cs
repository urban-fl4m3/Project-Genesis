using System;

namespace Common.GameStateModule.States
{
    public interface IConcreteState<out TState> : IState
        where TState : Enum
    {
        TState State { get; }
    }
}