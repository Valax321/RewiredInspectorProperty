using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Valax321.RewiredActionProperty.Editor
{
    internal static class RewiredPropertyDrawerHelpers
    {
        public static void BuildValues(ref List<GUIContent> values, ref List<int> actionIDs, ref bool invalid, string className)
        {
            System.Type t = null;

            values.Clear();
            actionIDs.Clear();
            
            values.Add(new GUIContent("None"));
            actionIDs.Add(-1);

            try
            {
                t = System.Type.GetType(className);
                invalid = false;
            }
            catch
            {
                invalid = true;
                return;
            }

            if (t == null)
            {
                invalid = true;
                return;
            }

            var fields = from field in t.GetFields(BindingFlags.Static | BindingFlags.Public)
                select new {id = (int) field.GetValue(null), name = field.Name};

            foreach (var field in fields)
            {
                actionIDs.Add(field.id);
                values.Add(new GUIContent(field.name));
            }
        }
    }
}