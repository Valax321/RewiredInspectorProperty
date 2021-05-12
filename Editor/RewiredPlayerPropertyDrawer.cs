using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Valax321.RewiredActionProperty.Editor
{
    [CustomPropertyDrawer(typeof(RewiredPlayer))]
    public class PlayerPropertyDrawer : RewiredBasePropertyDrawer
    {
        protected override string classnameSettingsKey => "playerClassname";
        protected override string propertyNameField => "m_playerID";
    }
}