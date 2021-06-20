using System;
using Common.UI.Base;
using Common.UI.Configurations;
using Common.UI.Enums;
using Object = UnityEngine.Object;

namespace Common.UI.Factories
{
    public class ViewFactory : IVIewFactory
    {
        private readonly IViewProvider _viewProvider;
        
        public ViewFactory(IViewProvider viewProvider)
        {
            _viewProvider = viewProvider;
        }

        public IView Create(Window type)
        {
            var (rawCanvas, rawWindow) = _viewProvider.GetWindowInfrastructure(type);
            var canvas = Object.Instantiate(rawCanvas);
            var window = Object.Instantiate(rawWindow, canvas.transform);
            var view = window.GetComponent<IView>();

            return view;
        }
    }
}