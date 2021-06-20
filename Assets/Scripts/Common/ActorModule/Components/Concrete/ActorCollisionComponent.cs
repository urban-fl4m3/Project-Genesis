using System;
using UnityEngine;

namespace Common.ActorModule.Components.Concrete
{
    public class ActorCollisionComponent : MonoBehaviour, IActorComponent
    {
        public event EventHandler Selected;
        public event EventHandler Deselected;
        
        public Collider Collider => _collider;
        [SerializeField] private Collider _collider;

        private bool _isActive;
        
        public void Activate()
        {
            _isActive = true;
        }

        public void Deactivate()
        {
            _isActive = false;
        }
        
        private void OnMouseOver()
        {
            if (!_isActive)
            {
                return;
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                Selected?.Invoke(this, null);
            }

            if (Input.GetMouseButtonUp(0))
            {
                Deselected?.Invoke(this, null);
            }
        }

        private void OnMouseUp()
        {
            if (!_isActive)
            {
                return;
            }
            
            Deselected?.Invoke(this,null);
        }
    }
}