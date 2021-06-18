using Common.Generics;
using Common.UI.Base;

namespace Common.UI.Views.BattleHud
{
    public class BattleHudViewModel : IViewModel
    {
        public readonly int PreparationTime;
        public readonly DynamicProperty<int> RoundNumber;
        public readonly DynamicProperty<int> CoinsNumber;
        
        public BattleHudViewModel(int preparationTime, DynamicProperty<int> roundNumber, DynamicProperty<int> coinsNumber)
        {
            PreparationTime = preparationTime;
            RoundNumber = roundNumber;
            CoinsNumber = coinsNumber;
        }
    }
}