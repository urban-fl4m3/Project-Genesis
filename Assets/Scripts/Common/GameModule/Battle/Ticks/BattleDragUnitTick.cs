using System;
using Common.ActorModule.Components;
using Common.ActorModule.Components.Concrete;
using Common.Generics;
using Common.TickModule;
using UnityEngine;

namespace Common.GameModule.Battle.Ticks
{
    public class BattleDragUnitTick : ITickUpdate
    {
        public bool Enabled
        {
            get => _enabled;
            set
            {
                if (value)
                {
                    _selectedActor.Changed += SelectedActorOnChanged;
                }
                else
                {
                    _selectedActor.Changed -= SelectedActorOnChanged;   
                }

                _enabled = value;
            }
        }
        
        private readonly Camera _camera;
        private readonly BattleSideComponent _sideComponent;
        private readonly DynamicProperty<IActor> _selectedActor;

        private bool _enabled;
        private bool _isDragging;
        private ActorTransformComponent _dragTransform;
        private ActorCollisionComponent _collisionComponent;
        
        public BattleDragUnitTick(DynamicProperty<IActor> selectedActor, IActor cameraActor, BattleSideComponent sideComponent)
        {
            _selectedActor = selectedActor;
            _sideComponent = sideComponent;
            _camera = cameraActor.GetActorComponent<ActorCameraComponent>().Camera;
        }
        
        public void Tick()
        {
            if (_isDragging)
            {
                var ray = _camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit, 30, _sideComponent.PlayerLayer))
                {
                    _dragTransform.Transform.position = hit.point;
                }
            }
        }

        private void SelectedActorOnChanged(object sender, IActor e)
        {
            _dragTransform = e.GetActorComponent<ActorTransformComponent>();
            
            if (_collisionComponent != null)
            {
                _collisionComponent.Selected -= CollisionComponentOnSelected;
                _collisionComponent.Deselected -= CollisionComponentOnDeselected;
            }
        
            _collisionComponent = e.GetActorComponent<ActorCollisionComponent>();
            _collisionComponent.Selected += CollisionComponentOnSelected;
            _collisionComponent.Deselected += CollisionComponentOnDeselected;
        }
        
        private void CollisionComponentOnSelected(object sender, EventArgs e)
        {
            _isDragging = true;
        }

        private void CollisionComponentOnDeselected(object sender, EventArgs e)
        {
            _isDragging = false;
        }
    }
}