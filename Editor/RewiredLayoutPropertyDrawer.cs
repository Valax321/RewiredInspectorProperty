using UnityEditor;

namespace Valax321.RewiredActionProperty.Editor
{
    public abstract class RewiredBaseLayoutPropertyDrawer : RewiredBasePropertyDrawer
    {
        protected override string propertyNameField => "m_layoutID";
    }

    [CustomPropertyDrawer(typeof(RewiredMouseLayout))]
    public class RewiredMouseLayoutPropertyDrawer : RewiredBaseLayoutPropertyDrawer
    {
        protected override string classnameSettingsKey => "mouseLayoutClassname";
    }
    
    [CustomPropertyDrawer(typeof(RewiredKeyboardLayout))]
    public class RewiredKeyboardLayoutPropertyDrawer : RewiredBaseLayoutPropertyDrawer
    {
        protected override string classnameSettingsKey => "keyboardLayoutClassname";
    }
    
    [CustomPropertyDrawer(typeof(RewiredJoystickLayout))]
    public class RewiredJoystickLayoutPropertyDrawer : RewiredBaseLayoutPropertyDrawer
    {
        protected override string classnameSettingsKey => "joystickLayoutClassname";
    }
    
    [CustomPropertyDrawer(typeof(RewiredCustomControllerLayout))]
    public class RewiredCustomControllerLayoutPropertyDrawer : RewiredBaseLayoutPropertyDrawer
    {
        protected override string classnameSettingsKey => "customControllerLayoutClassname";
    }
}