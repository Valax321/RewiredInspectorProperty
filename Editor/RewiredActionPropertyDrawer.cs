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
    public class RewiredActionPropertyDrawer : PropertyDrawer
    {
        private List<GUIContent> m_values = new List<GUIContent>();
        private List<int> m_actionIDs = new List<int>();
        private int m_selectedIndex;
        private bool m_invalidClass;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            RewiredPropertyDrawerHelpers.BuildValues(ref m_values, ref m_actionIDs, ref m_invalidClass, RewiredActionSettings.GetOrCreateSettings().m_actionClassname);

            if (!m_invalidClass)
            {
                EditorGUI.BeginProperty(position, label, property);

                var id = property.FindPropertyRelative("m_actionID");
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
                    $"Unknown class {RewiredActionSettings.GetOrCreateSettings().m_actionClassname} in settings.",
                    MessageType.Error);
            }
        }
    }
}