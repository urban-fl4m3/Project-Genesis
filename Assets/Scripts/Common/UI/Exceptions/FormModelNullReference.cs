using System;

namespace Common.UI.Exceptions
{
    public class FormModelNullReference : Exception
    {
        public FormModelNullReference()
        {
            
        }

        public FormModelNullReference(string message) : base(message)
        {
            
        }

        public FormModelNullReference(string message, Exception inner) : base(message, inner)
        {
            
        }
    }
}