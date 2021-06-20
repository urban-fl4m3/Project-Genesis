using Common.TickModule;
using Zenject;

namespace Common.Zenject.Bindings
{
    public static class TickBindings
    {
        public static void Bind(DiContainer container)
        {
            container
                .Bind<ITickManager>()
                .To<TickManager>()
                .AsSingle();
        } 
    }
}