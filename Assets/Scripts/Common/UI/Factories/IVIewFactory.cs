using Common.UI.Base;
using Common.UI.Enums;

namespace Common.UI.Factories
{
    public interface IVIewFactory
    {
        IView Create(Window type);
    }
}