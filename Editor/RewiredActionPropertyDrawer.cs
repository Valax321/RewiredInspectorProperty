using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Valax321.RewiredActionProperty.Editor
{
    [CustomPropertyDrawer(typeof(RewiredAction))]
    public class ActionPropertyDrawer : RewiredBasePropertyDrawer
    {
        protected override string classnameSettingsKey => "actionClassname";
        protected override string propertyNameField => "m_actionID";
    }
}