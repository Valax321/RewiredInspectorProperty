using System;
using UnityEngine;

namespace Valax321.RewiredActionProperty
{
    /// <summary>
    /// Wrapper class for a Rewired map category ID.
    /// </summary>
    [System.Serializable]
    public struct RewiredMapCategory : IEquatable<RewiredMapCategory>
    {
        [SerializeField] private int m_categoryID;

        /// <summary>
        /// The ID associated with this category.
        /// </summary>
        public int categoryID => m_categoryID;

        /// <summary>
        /// Create a new <see cref="RewiredMapCategory"/> instance with the specified ID.
        /// </summary>
        /// <param name="categoryID"></param>
        public RewiredMapCategory(int categoryID)
        {
            m_categoryID = categoryID;
        }

        public static implicit operator int(RewiredMapCategory @this)
        {
            return @this.m_categoryID;
        }

        public bool Equals(RewiredMapCategory other)
        {
            return m_categoryID == other.m_categoryID;
        }

        public override bool Equals(object obj)
        {
            return obj is RewiredMapCategory other && Equals(other);
        }

        public override int GetHashCode()
        {
            return categoryID;
        }

        public static bool operator ==(RewiredMapCategory left, RewiredMapCategory right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(RewiredMapCategory left, RewiredMapCategory right)
        {
            return !left.Equals(right);
        }
    }
}
