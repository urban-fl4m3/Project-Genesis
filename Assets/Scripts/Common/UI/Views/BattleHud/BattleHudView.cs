using System.Collections;
using Common.UI.Base;
using TMPro;
using UnityEngine;

namespace Common.UI.Views.BattleHud
{
    public class BattleHudView : BaseView<BattleHudViewModel>
    {
        [SerializeField] private TextMeshProUGUI _preparationTimeText;
        [SerializeField] private TextMeshProUGUI _roundNumberText;
        [SerializeField] private TextMeshProUGUI _coinsNumberText;

        private Coroutine _timerRoutine;
        private readonly WaitForSeconds _waitForSecond = new WaitForSeconds(1);
        
        protected override void OnActivate()
        {
            Model.CoinsNumber.Changed += CoinsNumberOnChanged;    
            Model.RoundNumber.Changed += RoundNumberOnChanged;
            _timerRoutine = StartCoroutine(TimerRoutine(Model.PreparationTime));
        }

        private void RoundNumberOnChanged(object sender, int e)
        {
            _roundNumberText.text = $"{e}";
        }

        private void CoinsNumberOnChanged(object sender, int e)
        {
            _coinsNumberText.text = $"{e}$";
        }

        private IEnumerator TimerRoutine(int seconds)
        {
            var estimatedTime = seconds;

            while (estimatedTime > 0)
            {
                yield return _waitForSecond;
                estimatedTime--;
                _preparationTimeText.text = $"{estimatedTime}";
            }
        }

        protected override void OnDeactivate()
        {
            Model.CoinsNumber.Changed -= CoinsNumberOnChanged;    
            Model.RoundNumber.Changed -= RoundNumberOnChanged;
            
            StopCoroutine(_timerRoutine);
            _timerRoutine = null;
        }
    }
}