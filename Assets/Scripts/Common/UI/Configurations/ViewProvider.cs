using System;
using System.Collections.Generic;
using System.Linq;
using Common.UI.DataModels;
using Common.UI.Enums;
using Common.UI.Exceptions;
using UnityEngine;

namespace Common.UI.Configurations
{
    [CreateAssetMenu(fileName = nameof(ViewProvider), menuName = "Data/UI/View Provider")]
    public class ViewProvider : ScriptableObject, IViewProvider, ISerializationCallbackReceiver
    {
        [SerializeField] private List<WindowDataModel> _windowModels;
        [SerializeField] private List<FormDataModel> _formModels;
        
        private Dictionary<Window, WindowDataModel> _windowsDict = new Dictionary<Window, WindowDataModel>();
        private Dictionary<Form, FormDataModel> _formDict = new Dictionary<Form, FormDataModel>();
        
        public void OnBeforeSerialize() { }

        public void OnAfterDeserialize()
        {
            _windowsDict = _windowModels.ToDictionary(
                x => x.WindowType, x => x);
            _formDict = _formModels.ToDictionary(
                x => x.Type, x => x);
        }

        public Tuple<Canvas, GameObject> GetWindowInfrastructure(Window type)
        {
            if (!_windowsDict.TryGetValue(type, out var windowModel))
            {
                throw new WindowModelNullReference($"Window model of type {type} doesn't exists in view provider.");
            }

            if (!_formDict.TryGetValue(windowModel.FormType, out var formModel))
            {
                throw new FormModelNullReference($"Form model of {windowModel.FormType} doesn't exists in view provider.");
            }

            return new Tuple<Canvas, GameObject>(formModel.Object, windowModel.Object);
        }
    }
}