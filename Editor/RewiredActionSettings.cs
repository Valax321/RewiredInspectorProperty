using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Valax321.RewiredActionProperty.Editor
{
    public class RewiredActionSettings : ScriptableObject
    {
        public const string k_SettingsPath = "Assets/Editor/RewiredActionSettings.asset";

        [SerializeField] public string m_actionClassname;
        [SerializeField] public string m_playerClassname;

        internal static void DrawSettingsGUI(string searchContext)
        {
            var settings = GetSerializedSettings();

            var actionClassname = settings.FindProperty(nameof(m_actionClassname));
            var playerClassname = settings.FindProperty(nameof(m_playerClassname));

            ClassnameChoiceProperty(actionClassname, (types) => from type in types
                where type.Name.Equals("Action") ||
                      type.FullName.Contains("Rewired") && !type.Assembly.FullName.Contains("Rewired")
                select type.AssemblyQualifiedName);
            
            ClassnameChoiceProperty(playerClassname, (types) => from type in types
                where type.Name.Equals("Player") ||
                      type.FullName.Contains("Rewired") && !type.Assembly.FullName.Contains("Rewired")
                select type.AssemblyQualifiedName);
            
            settings.ApplyModifiedProperties();
        }

        internal static void ClassnameChoiceProperty(SerializedProperty property, Func<TypeCache.TypeCollection, IEnumerable<string>> labelFunc)
        {
            var types = TypeCache.GetTypesDerivedFrom<object>();
            var labels = labelFunc(types).ToList();

            labels.Insert(0, "None");

            int index = 0;
            if (labels.Contains(property.stringValue))
                index = labels.IndexOf(property.stringValue);

            index = EditorGUILayout.Popup(new GUIContent(property.displayName), index, labels.ToArray());
            property.stringValue = labels[index];
        }

        internal static RewiredActionSettings GetOrCreateSettings()
        {
            var settings = AssetDatabase.LoadAssetAtPath<RewiredActionSettings>(k_SettingsPath);
            if (settings == null)
            {
                settings = ScriptableObject.CreateInstance<RewiredActionSettings>();
                settings.m_actionClassname = "RewiredConsts.Action, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null"; // This is where the class is most likely by default
                settings.m_playerClassname =
                    "RewiredConsts.Player, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null";
                AssetDatabase.CreateFolder("Assets", "Editor");
                AssetDatabase.CreateAsset(settings, k_SettingsPath);
                AssetDatabase.SaveAssets();
            }

            return settings;
        }

        internal static SerializedObject GetSerializedSettings()
        {
            return new SerializedObject(GetOrCreateSettings());
        }
    }
}