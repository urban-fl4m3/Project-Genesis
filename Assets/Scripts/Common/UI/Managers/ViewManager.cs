using System.Collections.Generic;
using System.Linq;
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

        public IView AddView(Window type, IViewModel model)
        {
            var view = _views.FirstOrDefault(instance => instance.Type == type);
            view ??= _viewFactory.Create(type);
            view.Activate(type, model);
            _views.Add(view);

            return view;
        }

        public IView GetView(Window type)
        {
            return _views.FirstOrDefault(x => x.Type == type);
        }
    }
}