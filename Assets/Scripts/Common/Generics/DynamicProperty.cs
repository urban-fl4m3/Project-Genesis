using System;

namespace Common.Generics
{
    public class DynamicProperty<T>
    {
        public event EventHandler<T> Changed;
        
        private T _value;
        
        public DynamicProperty(T value)
        {
            _value = value;
        }

        public DynamicProperty()
        {
            _value = default;
        }

        public T Value
        {
            get => _value;
            set
            {
                if (_value == null || !_value.Equals(value))
                {
                    _value = value;
                    Changed?.Invoke(this, value);
                }
            }
        }
    }
}