namespace Common.UI.Base
{
    public interface IView
    {
        void Activate(IViewModel model);
        void Deactivate();
        void Show();
        void Hide();
    }
}