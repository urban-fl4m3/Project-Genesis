using System;
using Common.UI.Enums;
using UnityEngine;

namespace Common.UI.DataModels
{
    [Serializable]
    public class FormDataModel
    {
        [SerializeField] private Form _formType;
        [SerializeField] private Canvas _formObject;

        public Form Type => _formType;
        public Canvas Object => _formObject;
    }
}