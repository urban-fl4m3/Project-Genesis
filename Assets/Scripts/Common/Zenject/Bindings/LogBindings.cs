using Common.Logger;
using Zenject;

namespace Common.Zenject.Bindings
{
    public static class LogBindings
    {
        public static void Bind(DiContainer container)
        {
            container
                .Bind<ILogger>()
#if UNITY_EDITOR
                .To<UnityLogger>()
#else
                .To<FakeLogger>()
#endif
                .AsSingle();
        }
    }
}