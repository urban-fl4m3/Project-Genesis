using UnityEngine;

namespace Common.ActorModule.Components.Concrete
{
    public class BattleSideComponent : MonoBehaviour, IActorComponent
    {
        [SerializeField] private LayerMask _playerLayer;
        [SerializeField] private GameObject _playerSideObject;
        [SerializeField] private LayerMask _enemyLayer;
        [SerializeField] private GameObject _enemySideObject;

        public LayerMask PlayerLayer => _playerLayer;
        public LayerMask EnemyLayer => _enemyLayer;
        public GameObject PlayerSide => _playerSideObject;
        public GameObject EnemySide => _enemySideObject;
        
        public void Activate()
        {
            
        }

        public void Deactivate()
        {
            
        }
    }
}