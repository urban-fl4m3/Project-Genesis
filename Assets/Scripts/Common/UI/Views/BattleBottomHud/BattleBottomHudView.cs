using Common.UI.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Common.UI.Views.BattleBottomHud
{
    public class BattleBottomHudView : BaseView<BattleBottomHudViewModel>
    {
        [SerializeField] private Button _shopButton;

        protected override void OnActivate()
        {
            _shopButton.onClick.AddListener(OpenShop);
        }

        private void OpenShop()
        {
            ActionHandler.Perform("open_shop");
        }

        protected override void OnDeactivate()
        {
            _shopButton.onClick.RemoveListener(OpenShop);
        }
    }
}