using UnityEngine;

namespace Valax321.RewiredActionProperty
{
    /// <summary>
    /// Wrapper class for a Rewired map category ID.
    /// </summary>
    [System.Serializable]
    public struct RewiredMapCategory
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
    }
}