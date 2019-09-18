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
            BuildValues();

            if (!m_invalidClass)
            {
                EditorGUI.BeginProperty(position, label, property);

                var id = property.FindPropertyRelative("m_actionID");
                m_selectedIndex = m_actionIDs.IndexOf(id.intValue);
                m_selectedIndex = EditorGUI.Popup(position, label, m_selectedIndex, m_values.ToArray());
                id.intValue = m_actionIDs[m_selectedIndex];

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

        private void BuildValues()
        {
            System.Type t = null;

            m_values.Clear();
            m_actionIDs.Clear();
            
            m_values.Add(new GUIContent("None"));
            m_actionIDs.Add(-1);

            try
            {
                t = System.Type.GetType(RewiredActionSettings.GetOrCreateSettings().m_actionClassname);
                m_invalidClass = false;
            }
            catch
            {
                m_invalidClass = true;
                return;
            }

            if (t == null)
            {
                m_invalidClass = true;
                return;
            }

            var fields = from field in t.GetFields(BindingFlags.Static | BindingFlags.Public)
                select new {id = (int) field.GetValue(null), name = field.Name};

            foreach (var field in fields)
            {
                m_actionIDs.Add(field.id);
                m_values.Add(new GUIContent(field.name));
            }
        }
    }
}