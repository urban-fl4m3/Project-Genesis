using Common.ActorModule;
using Common.GameModule.Battle.Attributes.Providers;

namespace Common.GameModule.Battle.Units.Configs
{
    public interface IUnitDataProvider
    {
        string Name { get; }
        Actor Actor { get; }
        AttributesDataProvider Attributes { get; }
    }
}