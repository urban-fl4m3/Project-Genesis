using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Generics
{
    public class TypeContainer
    {
        private readonly Dictionary<Type, object> _map;

        public TypeContainer()
        {
            _map = new Dictionary<Type, object>();
        }

        public void Add(Type type, object instance)
        {
            _map.Add(type, instance);
        }
        
        public void Add<T>(object instance)
        {
            _map.Add(typeof(T), instance);
        }
        
        public object Resolve(Type type)
        {
            return _map.ContainsKey(type) ? _map[type] : null;
        }

        public T Resolve<T>() where T : class
        {
            return _map.ContainsKey(typeof(T)) ? _map[typeof(T)] as T : null;
        }

        public List<T> GetList<T>()
        {
            var list = _map.Values.ToList();
            var components = (from o in list
                select (T) o).ToList();
            return components;
        }
    }
}