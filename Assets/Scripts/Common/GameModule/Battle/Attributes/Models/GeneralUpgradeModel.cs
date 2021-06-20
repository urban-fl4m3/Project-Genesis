using System;
using System.Collections.Generic;
using Common.GameModule.Battle.Attributes.Helpers;
using UnityEngine;

namespace Common.GameModule.Battle.Attributes.Models
{
    [Serializable]
    public class GeneralUpgradeModel
    {
        [SerializeField] public GeneralAttribute Attribute;
        [SerializeField] public List<UpgradeModel> CommonUpgrades;
        [SerializeField] public List<UpgradeModel> SpecialUpgrades;
    }
}