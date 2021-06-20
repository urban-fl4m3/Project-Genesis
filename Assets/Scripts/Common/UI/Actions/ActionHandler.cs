using System;
using Common.UI.Actions.Args;

namespace Common.UI.Actions
{
    public class ActionHandler
    {
        public event EventHandler<ActionPerformArgs> ActionPerformed;
        
        public void Perform(string actionName)
        {
            ActionPerformed?.Invoke(this, new ActionPerformArgs(actionName, null));
        }

        public void Perform(string actionName, object context)
        {
            ActionPerformed?.Invoke(this, new ActionPerformArgs(actionName, context));
        }

        public void Perform(ActionPerformArgs performArgs)
        {
            ActionPerformed?.Invoke(this, performArgs);
        }
    }
}