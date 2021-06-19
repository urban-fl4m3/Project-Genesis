using UnityEngine;

namespace Common.UI.Base
{
    public class BaseView<TViewModel> : MonoBehaviour, IView
        where TViewModel : IViewModel
    {
        protected TViewModel Model { get; private set; }

        public void Activate(IViewModel model)
        {
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
    }
}