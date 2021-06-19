using System;

namespace Common.GameStateModule.States.Exceptions
{
    public class GameStateNullReference : Exception
    {
        public GameStateNullReference() { }
        public GameStateNullReference(string message) : base(message) { }
        public GameStateNullReference(string message, Exception inner) : base(message, inner) { }
    }
}