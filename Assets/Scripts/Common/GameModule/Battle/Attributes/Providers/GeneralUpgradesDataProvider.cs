using System.Collections.Generic;
using System.Linq;
using Common.GameModule.Battle.Attributes.Helpers;
using Common.GameModule.Battle.Attributes.Models;
using UnityEngine;

namespace Common.GameModule.Battle.Attributes.Providers
{
    [CreateAssetMenu(fileName = nameof(GeneralUpgradesDataProvider), menuName = "Data/Game/General Attribute Upgrades")]
    public class GeneralUpgradesDataProvider : ScriptableObject, ISerializationCallbackReceiver, IGeneralUpgradesDataProvider
    {
        [SerializeField] private List<GeneralUpgradeModel> _generalUpgradeModels;

        private Dictionary<GeneralAttribute, GeneralUpgradeModel> _generalUpgradeModelsDict;
        
        public void OnBeforeSerialize()
        {
            
        }

        public void OnAfterDeserialize()
        {
            _generalUpgradeModelsDict = _generalUpgradeModels
                .ToDictionary(x => x.Attribute, x => x);
        }

        public IEnumerable<UpgradeModel> GetCommonUpgrades(GeneralAttribute attribute)
        {
            return _generalUpgradeModelsDict[attribute].CommonUpgrades;
        }
        
        public IEnumerable<UpgradeModel> GetSpecialUpgrades(GeneralAttribute attribute)
        {
            return _generalUpgradeModelsDict[attribute].SpecialUpgrades;
        }
    }
}