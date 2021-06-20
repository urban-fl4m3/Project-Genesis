using System.Collections.Generic;
using Common.GameModule.Battle.Attributes.Models;
using UnityEngine;

namespace Common.GameModule.Battle.Attributes.Providers
{
    [CreateAssetMenu(fileName = "New Attributes Data Provider", menuName = "Data/Game/Attributes Provider")]
    public class AttributesDataProvider : ScriptableObject
    {
        [SerializeField] public List<GeneralAttributeUpgradeModel> GeneralUpgradeModels;
        [SerializeField] public List<SecondaryAttributeUpgradeModel> SecondaryUpgradeModels;
    }
}