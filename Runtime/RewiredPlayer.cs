using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valax321.RewiredActionProperty
{
    /// <summary>
    /// Wrapper for a Rewired player ID.
    /// </summary>
    [System.Serializable]
    public struct RewiredPlayer
    {
        [SerializeField] private int m_actionID;

        /// <summary>
        /// The ID associated with this action.
        /// </summary>
        public int actionID => m_actionID;

        /// <summary>
        /// Create a new <see cref="RewiredPlayer"/> instance with the specified ID.
        /// </summary>
        /// <param name="actionID"></param>
        public RewiredPlayer(int actionID)
        {
            m_actionID = actionID;
        }

        public static implicit operator int(RewiredPlayer @this)
        {
            return @this.m_actionID;
        }
    }
}