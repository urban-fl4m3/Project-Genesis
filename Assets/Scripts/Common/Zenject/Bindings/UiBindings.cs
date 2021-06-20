using Common.UI.Configurations;
using Common.UI.Factories;
using Common.UI.Managers;
using Zenject;

namespace Common.Zenject.Bindings
{
    public static class UiBindings
    {
        public static void Bind(DiContainer container)
        {
            container
                .Bind<IViewProvider>()
                .To<ViewProvider>()
                .FromScriptableObjectResource($"Data/UI/{nameof(ViewProvider)}")
                .AsSingle();

            container
                .Bind<IVIewFactory>()
                .To<ViewFactory>()
                .AsSingle();

            container
                .Bind<IViewManager>()
                .To<ViewManager>()
                .AsSingle();
        }
    }
}