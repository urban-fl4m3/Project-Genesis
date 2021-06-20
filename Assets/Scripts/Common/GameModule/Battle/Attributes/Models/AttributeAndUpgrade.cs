using System;
using System.Collections.Generic;
using UnityEngine;

namespace Common.GameModule.Battle.Attributes.Models
{
    [Serializable]
    public struct AttributeAndUpgrade
    {
        [SerializeField] public float Value;
        [SerializeField] public float Upgrade;
    }
}