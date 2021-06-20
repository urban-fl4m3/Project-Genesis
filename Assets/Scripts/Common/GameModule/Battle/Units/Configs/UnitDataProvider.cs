using Common.ActorModule;
using Common.ActorModule.Concrete;
using Common.GameModule.Battle.Attributes.Providers;
using UnityEngine;

namespace Common.GameModule.Battle.Units.Configs
{
    [CreateAssetMenu(fileName = nameof(UnitDataProvider), menuName = "Data/Game/Unit")]
    public class UnitDataProvider : ScriptableObject, IUnitDataProvider
    {
        [SerializeField] private string _name;
        [SerializeField] private BattleUnitActor _actor;
        [SerializeField] private AttributesDataProvider _attributes;

        public string Name => _name;
        public Actor Actor => _actor;
        public AttributesDataProvider Attributes => _attributes;
    }
}