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
            RewiredPropertyDrawerHelpers.BuildValues(ref m_values, ref m_playerIDs, ref m_invalidClass, RewiredActionSettings.GetOrCreateSettings().m_playerClassname);

            if (!m_invalidClass)
            {
                EditorGUI.BeginProperty(position, label, property);

                var id = property.FindPropertyRelative("m_actionID");
                m_selectedIndex = m_playerIDs.IndexOf(id.intValue);
                m_selectedIndex = EditorGUI.Popup(position, label, m_selectedIndex, m_values.ToArray());
                id.intValue = m_playerIDs[m_selectedIndex];

                EditorGUI.EndProperty();
            }
            else
            {
                var pp = EditorGUI.PrefixLabel(position, label);
                EditorGUI.HelpBox(pp,
                    $"Unknown class {RewiredActionSettings.GetOrCreateSettings().m_playerClassname} in settings.",
                    MessageType.Error);
            }
        }        
    }
}