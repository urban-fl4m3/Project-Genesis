using System;

namespace Common.TickModule
{
    public class TickModuleInitializationError : Exception
    {
        public TickModuleInitializationError()
        {
            
        }

        public TickModuleInitializationError(string message) : base(message)
        {
            
        }

        public TickModuleInitializationError(string message, Exception inner) : base(message, inner)
        {
            
        }
    }
}