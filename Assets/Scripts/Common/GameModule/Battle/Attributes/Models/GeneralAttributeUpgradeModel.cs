using System;
using Common.GameModule.Battle.Attributes.Helpers;
using UnityEngine;

namespace Common.GameModule.Battle.Attributes.Models
{
    [Serializable]
    public struct GeneralAttributeUpgradeModel
    {
        [SerializeField] public GeneralAttribute Attribute;
        [SerializeField] public AttributeAndUpgrade UpgradeModel;
    }
}