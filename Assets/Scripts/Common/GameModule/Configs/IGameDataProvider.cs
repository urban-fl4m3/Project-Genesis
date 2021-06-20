namespace Common.GameModule.Configs
{
    public interface IGameDataProvider
    {
        int StartingGold { get; }
        int MoneyMultiplier { get; }
        int PreparationTime { get; }
    }
}