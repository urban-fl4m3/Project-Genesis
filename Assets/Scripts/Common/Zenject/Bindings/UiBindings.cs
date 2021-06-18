using Common.UI.Configurations;
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
        }
    }
}