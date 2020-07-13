using UnityEditor;

namespace Valax321.RewiredActionProperty.Editor
{
    [CustomPropertyDrawer(typeof(RewiredMapCategory))]
    public class MapCategoryPropertyDrawer : RewiredBasePropertyDrawer
    {
        protected override string classnameSettingsKey => "categoryClassname";
        protected override string propertyNameField => "m_categoryID";
    }
}