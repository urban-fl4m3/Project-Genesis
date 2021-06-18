using System;
using Common.UI.Enums;
using UnityEngine;

namespace Common.UI.DataModels
{
    [Serializable]
    public class WindowDataModel
    {
        [SerializeField] private Window _windowType;
        [SerializeField] private Form _formType;
        [SerializeField] private GameObject _windowObject;

        public Window WindowType => _windowType;
        public Form FormType => _formType;
        public GameObject Object => _windowObject;
    }
}