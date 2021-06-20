using System.Collections.Generic;
using Common.GameModule.Battle.Attributes.Helpers;
using Common.GameModule.Battle.Attributes.Models;

namespace Common.GameModule.Battle.Attributes.Providers
{
    public interface IGeneralUpgradesDataProvider
    {
        IEnumerable<UpgradeModel> GetCommonUpgrades(GeneralAttribute attribute);
        IEnumerable<UpgradeModel> GetSpecialUpgrades(GeneralAttribute attribute);
    }
}