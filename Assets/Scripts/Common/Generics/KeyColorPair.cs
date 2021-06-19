using System;
using UnityEngine;

namespace Common.Generics
{
    [Serializable]
    public class KeyColorPair<TKey>
    {
        [SerializeField] private TKey _key;
        [SerializeField] private Color _color;

        public TKey Key => _key;
        public Color Color => _color;
    }
}