using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Valax321.RewiredActionProperty.Editor
{
    internal static class GlobalSettings
    {
        [SettingsProvider]
        static SettingsProvider PreferenceGUI()
        {
            return new SettingsProvider("Project/Rewired Action Editor", SettingsScope.Project)
            {
                guiHandler = RewiredActionSettings.DrawSettingsGUI,
                keywords = new[]
                {
                    "Rewired",
                    "Action",
                    "Player",
                    "ID",
                    "Classname"
                }
            };
        }
    }
}