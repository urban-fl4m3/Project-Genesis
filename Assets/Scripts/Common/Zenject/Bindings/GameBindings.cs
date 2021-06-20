using Common.GameModule.Battle.Attributes.Providers;
using Common.GameModule.Configs;
using Zenject;

namespace Common.Zenject.Bindings
{
    public static class GameBindings
    {
        public static void Bind(DiContainer container)
        {
            container
                .Bind<IGameDataProvider>()
                .To<GameDataProvider>()
                .FromScriptableObjectResource($"Data/Game/{nameof(GameDataProvider)}")
                .AsSingle();

            container
                .Bind<IGeneralUpgradesDataProvider>()
                .To<GeneralUpgradesDataProvider>()
                .FromScriptableObjectResource($"Data/Game/{nameof(GeneralUpgradesDataProvider)}")
                .AsSingle();
        }
    }
}