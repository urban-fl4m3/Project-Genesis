using System.Collections.Generic;
using UnityEngine;

namespace Common.TickModule
{
    public class TickManager : ITickManager
    {
        private readonly Dictionary<object, List<ITick>> _allTicks = new Dictionary<object, List<ITick>>();
        
        private TickProcessor _processor;

        public void Initialize()
        {
            if (_processor != null)
            {
                throw new TickModuleInitializationError($"Tick processor is already exists");
            }
            
            _processor = new GameObject("_Tick_Processor").AddComponent<TickProcessor>();
        }
        
        public void AddTick(object owner, ITickUpdate tick)
        {
            AddTickInternal(owner, tick);
            _processor.TickUpdates.Add(tick);
        }

        public void AddTick(object owner, ITickLateUpdate tick)
        {
            AddTickInternal(owner, tick);
            _processor.TickLateUpdates.Add(tick);
        }

        public void AddTick(object owner, ITickFixedUpdate tick)
        {
            AddTickInternal(owner, tick);
            _processor.TickFixedUpdates.Add(tick);
        }

        public void RemoveTick(ITickUpdate tickUpdate)
        {
            tickUpdate.Enabled = false;
            _processor.TickUpdates.Remove(tickUpdate);
        }

        public void RemoveTick(ITickLateUpdate tickUpdate)
        {
            tickUpdate.Enabled = false;
            _processor.TickLateUpdates.Remove(tickUpdate);
        }

        public void RemoveTick(ITickFixedUpdate tickFixedUpdate)
        {
            tickFixedUpdate.Enabled = false;
            _processor.TickFixedUpdates.Remove(tickFixedUpdate);
        }
        
        private void AddTickInternal(object owner, ITick tick)
        {
            var hasOwner = _allTicks.TryGetValue(owner, out var tickList);

            if (hasOwner)
            {
                tickList.Add(tick);
            }
            else
            {
                tickList = new List<ITick> {tick};
                _allTicks.Add(owner, tickList);
            }
            
            tick.Enabled = true;
        }
    }
}