using System;
using Common.UI.Enums;
using UnityEngine;

namespace Common.UI.Configurations
{
    public interface IViewProvider
    {
        Tuple<Canvas, GameObject> GetWindowInfrastructure(Window type);
    }
}