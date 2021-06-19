using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Common.GameStateModule.States.Battle.Enums;
using Common.Generics;
using Common.UI.Base;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Common.UI.Views.BattleHud
{
    public class BattleHudView : BaseView<BattleHudViewModel>
    {
        [SerializeField] private TextMeshProUGUI _preparationTimeText;
        [SerializeField] private TextMeshProUGUI _roundNumberText;
        [SerializeField] private TextMeshProUGUI _coinsNumberText;
        [SerializeField] private Image _roundImage;
        [SerializeField] private List<KeyColorPair<BattleMode>> _colors;
        
        protected override void OnActivate()
        {
            Model.CoinsNumber.Changed += CoinsNumberOnChanged;    
            Model.RoundNumber.Changed += RoundNumberOnChanged;
            Model.BattleState.Changed += BattleStateOnChanged;
            Model.PreparationTime.Changed += PreparationTimeOnChanged;
        }

        private void BattleStateOnChanged(object sender, BattleMode e)
        {
            var colorModel = _colors.FirstOrDefault(x => x.Key == e);
            var color = colorModel?.Color ?? Color.white;
            _roundImage.color = color;
        }

        private void RoundNumberOnChanged(object sender, int e)
        {
            _roundNumberText.text = $"{e}";
        }

        private void CoinsNumberOnChanged(object sender, int e)
        {
            _coinsNumberText.text = $"{e}$";
        }

        private void PreparationTimeOnChanged(object sender, int e)
        {
            _preparationTimeText.text = $"{e}";
        }
        
        protected override void OnDeactivate()
        {
            Model.CoinsNumber.Changed -= CoinsNumberOnChanged;    
            Model.RoundNumber.Changed -= RoundNumberOnChanged;
            Model.BattleState.Changed -= BattleStateOnChanged;
            Model.PreparationTime.Changed -= PreparationTimeOnChanged;
        }
    }
}