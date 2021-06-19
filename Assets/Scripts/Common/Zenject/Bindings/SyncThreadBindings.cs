using Common.SyncThreadModule;
using Zenject;

namespace Common.Zenject.Bindings
{
    public static class SyncThreadBindings
    {
        public static void Bind(DiContainer container)
        {
            container
                .Bind<ISyncProcessor>()
                .To<SyncProcessor>()
                .AsSingle();
        }
    }
}