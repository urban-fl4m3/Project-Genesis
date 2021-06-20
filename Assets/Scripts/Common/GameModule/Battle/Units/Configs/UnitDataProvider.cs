using Common.GameModule.Battle.Attributes.Providers;
using UnityEngine;

namespace Common.GameModule.Battle.Units.Configs
{
    [CreateAssetMenu(fileName = nameof(UnitDataProvider), menuName = "Data/Game/Unit")]
    public class UnitDataProvider : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private GameObject _unit;
        [SerializeField] private AttributesDataProvider _attributes;
    }
}