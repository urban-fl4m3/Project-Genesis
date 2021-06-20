using System;

namespace Common.UI.Actions.Args
{
    public class ActionPerformArgs : EventArgs
    {
        public readonly string ActionName;
        public readonly object Context;
        
        public ActionPerformArgs(string actionName, object context)
        {
            ActionName = actionName;
            Context = context;
        }
    }
}