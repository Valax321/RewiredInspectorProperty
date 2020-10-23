using System;
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
    public struct RewiredJoystickLayout : IRewiredLayout, IEquatable<RewiredJoystickLayout>
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

        public bool Equals(RewiredJoystickLayout other)
        {
            return m_layoutID == other.m_layoutID;
        }

        public override bool Equals(object obj)
        {
            return obj is RewiredJoystickLayout other && Equals(other);
        }

        public override int GetHashCode()
        {
            return layoutID;
        }

        public static bool operator ==(RewiredJoystickLayout left, RewiredJoystickLayout right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(RewiredJoystickLayout left, RewiredJoystickLayout right)
        {
            return !left.Equals(right);
        }
    }

    /// <summary>
    /// Wrapper class for a Rewired keyboard layout ID.
    /// </summary>
    [System.Serializable]
    public struct RewiredKeyboardLayout : IRewiredLayout, IEquatable<RewiredKeyboardLayout>
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

        public bool Equals(RewiredKeyboardLayout other)
        {
            return m_layoutID == other.m_layoutID;
        }

        public override bool Equals(object obj)
        {
            return obj is RewiredKeyboardLayout other && Equals(other);
        }

        public override int GetHashCode()
        {
            return layoutID;
        }

        public static bool operator ==(RewiredKeyboardLayout left, RewiredKeyboardLayout right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(RewiredKeyboardLayout left, RewiredKeyboardLayout right)
        {
            return !left.Equals(right);
        }
    }

    /// <summary>
    /// Wrapper class for a Rewired mouse layout ID.
    /// </summary>
    [System.Serializable]
    public struct RewiredMouseLayout : IRewiredLayout, IEquatable<RewiredMouseLayout>
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

        public bool Equals(RewiredMouseLayout other)
        {
            return m_layoutID == other.m_layoutID;
        }

        public override bool Equals(object obj)
        {
            return obj is RewiredMouseLayout other && Equals(other);
        }

        public override int GetHashCode()
        {
            return layoutID;
        }

        public static bool operator ==(RewiredMouseLayout left, RewiredMouseLayout right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(RewiredMouseLayout left, RewiredMouseLayout right)
        {
            return !left.Equals(right);
        }
    }

    /// <summary>
    /// Wrapper class for a Rewired custom controller layout ID.
    /// </summary>
    [System.Serializable]
    public struct RewiredCustomControllerLayout : IRewiredLayout, IEquatable<RewiredCustomControllerLayout>
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

        public bool Equals(RewiredCustomControllerLayout other)
        {
            return m_layoutID == other.m_layoutID;
        }

        public override bool Equals(object obj)
        {
            return obj is RewiredCustomControllerLayout other && Equals(other);
        }

        public override int GetHashCode()
        {
            return layoutID;
        }

        public static bool operator ==(RewiredCustomControllerLayout left, RewiredCustomControllerLayout right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(RewiredCustomControllerLayout left, RewiredCustomControllerLayout right)
        {
            return !left.Equals(right);
        }
    }
}
