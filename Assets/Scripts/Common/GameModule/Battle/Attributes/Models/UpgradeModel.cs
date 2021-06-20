using System;
using Common.GameModule.Battle.Attributes.Helpers;
using UnityEngine;

namespace Common.GameModule.Battle.Attributes.Models
{
    [Serializable]
    public struct UpgradeModel
    {
        [SerializeField] public BattleAttribute Attribute;
        [SerializeField] public float UpgradeValue;
    }
}