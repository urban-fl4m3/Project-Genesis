using System;
using Common.UI.Actions.Args;
using Common.UI.Enums;

namespace Common.UI.Base
{
    public interface IView
    {
        Window Type { get; }
        event EventHandler<ActionPerformArgs> ActionPerformed;
            
        void Activate(Window type, IViewModel model);
        void Deactivate();
        void Show();
        void Hide();
    }
}