using System;

namespace Common.StateModule.States
{
    public interface IConcreteState<out TState> : IState
        where TState : Enum
    {
        TState State { get; }
    }
}