using UnityEngine;

namespace Valax321.RewiredActionProperty
{
    /// <summary>
    /// Interface for all layout properties.
    /// </summary>
    public interface IRewiredLayout
    {
        /// <summary>
        /// The rewired ID for this layout.
        /// </summary>
        int layoutID { get; }
    }
    
    /// <summary>
    /// Wrapper class for a Rewired joystick layout ID.
    /// </summary>
    [System.Serializable]
    public struct RewiredJoystickLayout : IRewiredLayout
    {
        [SerializeField] private int m_layoutID;
        public int layoutID => m_layoutID;

        public RewiredJoystickLayout(int layoutID)
        {
            m_layoutID = layoutID;
        }
        
        public static implicit operator int(RewiredJoystickLayout @this)
        {
            return @this.m_layoutID;
        }
    }

    /// <summary>
    /// Wrapper class for a Rewired keyboard layout ID.
    /// </summary>
    [System.Serializable]
    public struct RewiredKeyboardLayout : IRewiredLayout
    {
        [SerializeField] private int m_layoutID;
        public int layoutID => m_layoutID;
        
        public RewiredKeyboardLayout(int layoutID)
        {
            m_layoutID = layoutID;
        }
        
        public static implicit operator int(RewiredKeyboardLayout @this)
        {
            return @this.m_layoutID;
        }
    }

    /// <summary>
    /// Wrapper class for a Rewired mouse layout ID.
    /// </summary>
    [System.Serializable]
    public struct RewiredMouseLayout : IRewiredLayout
    {
        [SerializeField] private int m_layoutID;
        public int layoutID => m_layoutID;
        
        public RewiredMouseLayout(int layoutID)
        {
            m_layoutID = layoutID;
        }
        
        public static implicit operator int(RewiredMouseLayout @this)
        {
            return @this.m_layoutID;
        }
    }
    
    /// <summary>
    /// Wrapper class for a Rewired custom controller layout ID.
    /// </summary>
    [System.Serializable]
    public struct RewiredCustomControllerLayout : IRewiredLayout
    {
        [SerializeField] private int m_layoutID;
        public int layoutID => m_layoutID;

        public RewiredCustomControllerLayout(int layoutID)
        {
            m_layoutID = layoutID;
        }
        
        public static implicit operator int(RewiredCustomControllerLayout @this)
        {
            return @this.m_layoutID;
        }
    }
}