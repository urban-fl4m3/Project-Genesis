using Common.UI.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Common.UI.Views.BattleShop
{
    public class BattleShopView : BaseView<BattleShopViewModel>
    {
        [SerializeField] private Button _closeButton;

        protected override void OnActivate()
        {
            _closeButton.onClick.AddListener(CloseShop);
        }

        private void CloseShop()
        {
            ActionHandler.Perform("close_shop");
        }

        protected override void OnDeactivate()
        {
            _closeButton.onClick.RemoveListener(CloseShop);
        }
    }
}