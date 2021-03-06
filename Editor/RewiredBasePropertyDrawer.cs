using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Valax321.RewiredActionProperty.Editor
{
    public abstract class RewiredBasePropertyDrawer : PropertyDrawer
    {
        private List<GUIContent> m_values = new List<GUIContent>();
        private List<int> m_actionIDs = new List<int>();
        private int m_selectedIndex;
        private bool m_invalidClass;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var value = RewiredSettingsManager.instance.Get<string>(classnameSettingsKey);
            
            RewiredPropertyDrawerHelpers.BuildValues(ref m_values, ref m_actionIDs, ref m_invalidClass, value);

            if (!m_invalidClass)
            {
                EditorGUI.BeginProperty(position, label, property);

                var id = property.FindPropertyRelative(propertyNameField);
                m_selectedIndex = m_actionIDs.IndexOf(id.intValue);
                m_selectedIndex = EditorGUI.Popup(position, label, m_selectedIndex, m_values.ToArray());
                if (m_selectedIndex < m_actionIDs.Count)
                    id.intValue = m_actionIDs[m_selectedIndex];
                else
                    id.intValue = m_actionIDs[0];

                EditorGUI.EndProperty();
            }
            else
            {
                var pp = EditorGUI.PrefixLabel(position, label);
                EditorGUI.HelpBox(pp,
                    $"Unknown class {value} in settings.",
                    MessageType.Error);
            }
        }
        
        protected abstract string classnameSettingsKey { get; }
        protected abstract string propertyNameField { get; }
    }
}