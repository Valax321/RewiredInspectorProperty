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

            var classname = settings.FindProperty(nameof(m_actionClassname));

            var types = TypeCache.GetTypesDerivedFrom<object>();
            var labels = (from type in types
                where type.Name.Equals("Action") ||
                      (type.FullName.Contains("Rewired") && !type.Assembly.FullName.Contains("Rewired"))
                select type.AssemblyQualifiedName).ToList();

            labels.Insert(0, "None");

            int index = 0;
            if (labels.Contains(classname.stringValue))
                index = labels.IndexOf(classname.stringValue);

            index = EditorGUILayout.Popup(new GUIContent("Action Class"), index, labels.ToArray());
            classname.stringValue = labels[index];
            settings.ApplyModifiedProperties();
        }

        internal static RewiredActionSettings GetOrCreateSettings()
        {
            var settings = AssetDatabase.LoadAssetAtPath<RewiredActionSettings>(k_SettingsPath);
            if (settings == null)
            {
                settings = ScriptableObject.CreateInstance<RewiredActionSettings>();
                settings.m_actionClassname = "RewiredConsts.Action, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null"; // This is where the class is most likely by default
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