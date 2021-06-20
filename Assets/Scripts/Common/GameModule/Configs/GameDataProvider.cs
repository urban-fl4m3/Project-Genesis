using System.Collections.Generic;
using Common.GameModule.Battle.Units.Configs;
using UnityEngine;

namespace Common.GameModule.Configs
{
    [CreateAssetMenu(fileName = nameof(GameDataProvider), menuName = "Data/Game/Common Data")]
    public class GameDataProvider : ScriptableObject, IGameDataProvider
    {
        [SerializeField] private int _startingGold;
        [SerializeField] private int _moneyMultiplier;
        [SerializeField] private int _preparationTime;
        [SerializeField] private List<UnitDataProvider> _unitData;

        public int StartingGold => _startingGold;
        public int MoneyMultiplier => _moneyMultiplier;
        public int PreparationTime => _preparationTime;
        
        public IReadOnlyList<UnitDataProvider> GetUnitData()
        {
            return _unitData;
        }
    }
}