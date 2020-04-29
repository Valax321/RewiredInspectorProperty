using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEditor.SettingsManagement;

namespace Valax321.RewiredActionProperty.Editor
{
    internal static class GlobalSettings
    {
        public const string PrefsPath = "com.valax321.rewiredinspectorproperty";
        
        [SettingsProvider]
        static SettingsProvider PreferenceGUI()
        {
            return new RewiredSettingsProvider("Project/Rewired Inspector Property", SettingsScope.Project, new []
            {
                "Rewired",
                "Action",
                "Player",
                "ID",
                "Classname"
            });
        }
    }

    internal static class RewiredSettingsManager
    {
        private static Settings s_instance;

        public static Settings instance
        {
            get
            {
                if (s_instance == null)
                {
                    s_instance = new Settings(GlobalSettings.PrefsPath);
                }

                return s_instance;
            }
        }
    }

    internal class RewiredSettingsProvider : SettingsProvider
    {
        public RewiredSettingsProvider(string path, SettingsScope scopes, IEnumerable<string> keywords = null) : base(path, scopes, keywords)
        {
        }

        public override void OnGUI(string searchContext)
        {
            var instance = RewiredSettingsManager.instance;
            
            var actionName = instance.Get("actionClassname", fallback: string.Empty);
            var playerName = instance.Get("playerClassname", fallback: string.Empty);
            
            EditorGUI.BeginChangeCheck();
            
            EditorGUILayout.LabelField("Rewired Constant Classes", EditorStyles.boldLabel);
            EditorGUILayout.Separator();

            var newName = ClassnameChoiceProperty("Action Class", actionName, (types) => from type in types
                where type.Name.Equals("Action") &&
                      (type.FullName.Contains("Rewired") && !type.Assembly.FullName.Contains("Rewired"))
                select type.AssemblyQualifiedName);

            var newPlayer = ClassnameChoiceProperty("Player Class", playerName, (types) => from type in types
                where type.Name.Equals("Player") &&
                      (type.FullName.Contains("Rewired") && !type.Assembly.FullName.Contains("Rewired"))
                select type.AssemblyQualifiedName);

            if (newName != actionName)
            {
                instance.Set("actionClassname", newName);
            }
            if (newPlayer != playerName)
            {
                instance.Set("playerClassname", newPlayer);
            }

            if (EditorGUI.EndChangeCheck())
            {
                instance.Save();
            }
        }
        
        internal static string ClassnameChoiceProperty(string name, string value, Func<TypeCache.TypeCollection, IEnumerable<string>> labelFunc)
        {
            var types = TypeCache.GetTypesDerivedFrom<object>();
            var labels = labelFunc(types).ToList();

            labels.Insert(0, "None");

            int index = 0;
            if (labels.Contains(value))
                index = labels.IndexOf(value);

            index = EditorGUILayout.Popup(new GUIContent(name), index, labels.ToArray());
            return labels[index];
        }
    }
}