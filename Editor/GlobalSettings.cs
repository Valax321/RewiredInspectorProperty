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
            return new RewiredSettingsProvider("Project/Rewired Inspector Properties", SettingsScope.Project, new []
            {
                "Rewired",
                "Action",
                "Player",
                "Category",
                "Map",
                "Layout",
                "Mouse",
                "Keyboard",
                "Joystick",
                "Controller",
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

            EditorGUI.BeginChangeCheck();
            
            EditorGUILayout.HelpBox("These settings tell the property fields where to find the binding information. If these are not set to valid classes, the properties will not function.", MessageType.Info);
            EditorGUILayout.Separator();
            EditorGUILayout.LabelField("Action Classes", EditorStyles.boldLabel);

            ClassnameChoiceProperty("actionClassname", "Action", (types) => from type in types
                where type.Name.Equals("Action") &&
                      (type.FullName.Contains("Rewired") && !type.Assembly.FullName.Contains("Rewired"))
                select type.AssemblyQualifiedName);
            
            EditorGUILayout.Separator();
            EditorGUILayout.LabelField("Player Classes", EditorStyles.boldLabel);

            ClassnameChoiceProperty("playerClassname", "Player", (types) => from type in types
                where type.Name.Equals("Player") &&
                      (type.FullName.Contains("Rewired") && !type.Assembly.FullName.Contains("Rewired"))
                select type.AssemblyQualifiedName);
            
            EditorGUILayout.Separator();
            EditorGUILayout.LabelField("Category Classes", EditorStyles.boldLabel);
            
            ClassnameChoiceProperty("categoryClassname", "Map Category", (types) => from type in types
                where type.Name.Equals("Category") &&
                      (type.FullName.Contains("Rewired") && !type.Assembly.FullName.Contains("Rewired"))
                select type.AssemblyQualifiedName);
            
            EditorGUILayout.Separator();
            EditorGUILayout.LabelField("Layout Classes", EditorStyles.boldLabel);
            
            ClassnameChoiceProperty("mouseLayoutClassname", "Mouse Layout", (types) => from type in types
                where type.Name.Equals("Mouse") && type.FullName.Contains("Layout") &&
                      (type.FullName.Contains("Rewired") && !type.Assembly.FullName.Contains("Rewired"))
                select type.AssemblyQualifiedName);
            
            ClassnameChoiceProperty("keyboardLayoutClassname", "Keyboard Layout", (types) => from type in types
                where type.Name.Equals("Keyboard") && type.FullName.Contains("Layout") &&
                      (type.FullName.Contains("Rewired") && !type.Assembly.FullName.Contains("Rewired"))
                select type.AssemblyQualifiedName);
            
            ClassnameChoiceProperty("joystickLayoutClassname", "Joystick Layout", (types) => from type in types
                where type.Name.Equals("Joystick") && type.FullName.Contains("Layout") &&
                      (type.FullName.Contains("Rewired") && !type.Assembly.FullName.Contains("Rewired"))
                select type.AssemblyQualifiedName);
            
            ClassnameChoiceProperty("customControllerLayoutClassname", "Custom Controller Layout", (types) => from type in types
                where type.Name.Equals("CustomController") && type.FullName.Contains("Layout") &&
                      (type.FullName.Contains("Rewired") && !type.Assembly.FullName.Contains("Rewired"))
                select type.AssemblyQualifiedName);

            if (EditorGUI.EndChangeCheck())
            {
                instance.Save();
            }
        }
        
        internal static void ClassnameChoiceProperty(string key, string name, Func<TypeCache.TypeCollection, IEnumerable<string>> labelFunc)
        {
            var instance = RewiredSettingsManager.instance;
            var settingLabel = instance.Get(key, fallback: string.Empty);
            
            var types = TypeCache.GetTypesDerivedFrom<object>();
            var labels = labelFunc(types).ToList();

            labels.Insert(0, "None");

            int index = 0;
            if (labels.Contains(settingLabel))
                index = labels.IndexOf(settingLabel);

            index = EditorGUILayout.Popup(new GUIContent(name), index, labels.ToArray());
            var label = labels[index];

            if (label != settingLabel)
            {
                instance.Set(key, label);
            }
        }
    }
}