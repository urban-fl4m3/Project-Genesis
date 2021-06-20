using System;
using System.Collections.Generic;

namespace Common.UI.Actions
{
    public class ActionContainer : IActionBinder
    {
        private readonly Dictionary<string, List<Action<object>>> _container = new Dictionary<string, List<Action<object>>>();

        public void Bind(string name, Action<object> a)
        {
            if (!_container.TryGetValue(name, out var actions))
            {
                actions = new List<Action<object>>();
                _container.Add(name, actions);
            }
            
            actions.Add(a);
        }

        public void Clear()
        {
            foreach (var actionPair in _container)
            {
                actionPair.Value.Clear();
            }
            
            _container.Clear();
        }

        public IEnumerable<Action<object>> GetActions(string name)
        {
            if (!_container.TryGetValue(name, out var actions))
            {
                return new Action<object>[0];
            }

            return actions;
        }
    }
}