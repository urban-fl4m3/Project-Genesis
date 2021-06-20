using System;
using Common.UI.Actions;
using Common.UI.Actions.Args;
using Common.UI.Base;
using Common.UI.Enums;
using Common.UI.Managers;

namespace Common.StateModule.States.Abstract
{
    public abstract class ViewState<TState> : IConcreteState<TState>
        where TState : Enum 
    {
        private readonly IViewManager _viewManager;
        private readonly ActionContainer _actionContainer;
        
        public abstract TState State { get; }

        protected ViewState(IViewManager viewManager)
        {
            _viewManager = viewManager;
            _actionContainer = new ActionContainer();
        }

        public virtual void Enter()
        {
            OnBindAction(_actionContainer);
        }

        public virtual void Exit()
        {
            OnUnbindAction(_actionContainer);    
        }

        protected virtual void OnBindAction(IActionBinder actionContainer) { }
        protected virtual void OnUnbindAction(IActionBinder actionContainer) { }
        
        protected void AddView(Window type, IViewModel model)
        {
            var view = _viewManager.AddView(type, model);
            view.Show();
            view.ActionPerformed += ViewOnActionPerformed;
        }

        protected void CloseView(Window type)
        {
            var view = _viewManager.GetView(type);

            if (view != null)
            {
                view.ActionPerformed -= ViewOnActionPerformed;
                view.Hide();
                view.Deactivate();
            }
        }

        private void ViewOnActionPerformed(object sender, ActionPerformArgs e)
        {
            var actions = _actionContainer.GetActions(e.ActionName);
            
            foreach (var action in actions)
            {
                action(e.Context);
            }
        }
    }
}