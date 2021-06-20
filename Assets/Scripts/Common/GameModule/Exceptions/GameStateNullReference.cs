using System;

namespace Common.GameModule.Exceptions
{
    public class GameStateNullReference : Exception
    {
        public GameStateNullReference() { }
        public GameStateNullReference(string message) : base(message) { }
        public GameStateNullReference(string message, Exception inner) : base(message, inner) { }
    }
}