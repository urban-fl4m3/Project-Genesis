using Common.UI.Base;
using UnityEngine;

namespace Common.UI.Views.BattleHud
{
    public class BattleHudController : IViewController
    {
        private readonly BattleHudView _view;
        
        public BattleHudController(GameObject prefab)
        {
            var viewInstance = Object.Instantiate(prefab);
            _view = viewInstance.GetComponent<BattleHudView>();
        }

        public void Show()
        {
            _view.Show();
        }

        public void Hide()
        {
            _view.Hide();
        }
    }
}