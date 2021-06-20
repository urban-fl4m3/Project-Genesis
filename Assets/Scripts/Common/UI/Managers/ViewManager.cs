using System.Collections.Generic;
using Common.UI.Base;
using Common.UI.Enums;
using Common.UI.Factories;

namespace Common.UI.Managers
{
    public class ViewManager : IViewManager
    {
        private readonly IVIewFactory _viewFactory;
        private readonly List<IView> _views = new List<IView>();
        
        public ViewManager(IVIewFactory viewFactory)
        {
            _viewFactory = viewFactory;
        }

        public void AddView(Window type, IViewModel model)
        {
            var view = _viewFactory.Create(type);
            view.Activate(model);
        }
    }
}