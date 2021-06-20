using Common.GameModule.Battle.Enums;
using Common.Generics;
using Common.UI.Base;

namespace Common.UI.Views.BattleUpperHud
{
    public class BattleUpperHudViewModel : IViewModel
    {
        public readonly DynamicProperty<int> PreparationTime;
        public readonly DynamicProperty<int> RoundNumber;
        public readonly DynamicProperty<int> CoinsNumber;
        public readonly DynamicProperty<BattleMode> BattleState;
        
        public BattleUpperHudViewModel(DynamicProperty<int> preparationTime, DynamicProperty<int> roundNumber,
            DynamicProperty<int> coinsNumber, DynamicProperty<BattleMode> battleState)
        {
            PreparationTime = preparationTime;
            RoundNumber = roundNumber;
            CoinsNumber = coinsNumber;
            BattleState = battleState;
        }
    }
}