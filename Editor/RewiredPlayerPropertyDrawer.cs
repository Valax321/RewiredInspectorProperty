using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Valax321.RewiredActionProperty.Editor
{
    [CustomPropertyDrawer(typeof(RewiredPlayer))]
    public class RewiredPlayerPropertyDrawer : PropertyDrawer
    {
        private List<GUIContent> m_values = new List<GUIContent>();
        private List<int> m_playerIDs = new List<int>();
        private int m_selectedIndex;
        private bool m_invalidClass;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var value = RewiredSettingsManager.instance.Get<string>("playerClassname");
            
            RewiredPropertyDrawerHelpers.BuildValues(ref m_values, ref m_playerIDs, ref m_invalidClass, value);

            if (!m_invalidClass)
            {
                EditorGUI.BeginProperty(position, label, property);

                var id = property.FindPropertyRelative("m_actionID");
                m_selectedIndex = m_playerIDs.IndexOf(id.intValue);
                m_selectedIndex = EditorGUI.Popup(position, label, m_selectedIndex, m_values.ToArray());
                id.intValue = m_playerIDs[m_selectedIndex];
                if (m_selectedIndex < m_playerIDs.Count)
                    id.intValue = m_playerIDs[m_selectedIndex];
                else
                    id.intValue = m_playerIDs[0];

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
    }
}