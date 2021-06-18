using System;

namespace Common.UI.Exceptions
{
    public class WindowModelNullReference : Exception
    {
        public WindowModelNullReference()
        {
            
        }

        public WindowModelNullReference(string message) : base(message)
        {
            
        }

        public WindowModelNullReference(string message, Exception inner) : base(message, inner)
        {
            
        }
    }
}