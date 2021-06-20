using System;

namespace Common.UI.Actions
{
    public interface IActionBinder
    {
        void Bind(string name, Action<object> a);
        void Clear();
    }
}