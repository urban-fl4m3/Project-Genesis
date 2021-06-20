using System.Collections.Generic;
using Common.ActorModule;
using Common.ActorModule.Components;
using Common.GameModule.Battle.Units.Configs;
using UnityEngine;

namespace Common.GameModule.Configs
{
    public interface IGameDataProvider
    {
        int StartingGold { get; }
        int MoneyMultiplier { get; }
        int PreparationTime { get; }

        IReadOnlyList<UnitDataProvider> GetUnitData();
        Actor GetBattleField();
    }
}