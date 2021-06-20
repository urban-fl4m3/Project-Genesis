using System.Collections.Generic;
using Common.GameModule.Battle.Units.Configs;

namespace Common.GameModule.Configs
{
    public interface IGameDataProvider
    {
        int StartingGold { get; }
        int MoneyMultiplier { get; }
        int PreparationTime { get; }

        IReadOnlyList<UnitDataProvider> GetUnitData();
    }
}