using Common.UI.Base;
using Common.UI.Enums;

namespace Common.UI.Managers
{
    public interface IViewManager
    {
        IView AddView(Window type, IViewModel model);
        IView GetView(Window type);
    }
}