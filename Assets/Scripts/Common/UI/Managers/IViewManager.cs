using Common.UI.Base;
using Common.UI.Enums;

namespace Common.UI.Managers
{
    public interface IViewManager
    {
        void AddView(Window type, IViewModel model);
    }
}