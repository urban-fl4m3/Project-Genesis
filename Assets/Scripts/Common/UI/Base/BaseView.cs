using System;
using Common.UI.Actions;
using Common.UI.Actions.Args;
using Common.UI.Enums;
using UnityEngine;

namespace Common.UI.Base
{
    public class BaseView<TViewModel> : MonoBehaviour, IView
        where TViewModel : IViewModel
    {
        public Window Type { get; private set; }
        public event EventHandler<ActionPerformArgs> ActionPerformed;
            
        protected TViewModel Model { get; private set; }
        protected ActionHandler ActionHandler { get; private set; }

        public void Activate(Window type, IViewModel model)
        {
            Type = type;
            ActionHandler = new ActionHandler();
            ActionHandler.ActionPerformed += ActionHandlerOnActionPerformed;
            Model = (TViewModel)model;
            OnActivate();
        }

        public void Deactivate()
        {
            OnDeactivate();
        }
        
        public void Show()
        {
            gameObject.SetActive(true);
            OnShow();
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            OnHide();
        }

        protected virtual void OnActivate() { }
        protected virtual void OnDeactivate() { }
        protected virtual void OnShow() { }
        protected virtual void OnHide() { }
        
        private void ActionHandlerOnActionPerformed(object sender, ActionPerformArgs e)
        {
            ActionPerformed?.Invoke(this, e);
        }
    }
}