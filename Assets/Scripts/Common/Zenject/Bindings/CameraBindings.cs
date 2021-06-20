using Common.CameraModule;
using Zenject;

namespace Common.Zenject.Bindings
{
    public static class CameraBindings
    {
        public static void Bind(DiContainer container)
        {
            container
                .Bind<ICameraManager>()
                .To<CameraManager>()
                .AsSingle();
        }
    }
}