using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valax321.RewiredActionProperty
{
    /// <summary>
    /// Wrapper class for a Rewired action ID.
    /// </summary>
    [System.Serializable]
    public struct RewiredAction : IEquatable<RewiredAction>
    {
        [SerializeField] private int m_actionID;

        /// <summary>
        /// The ID associated with this action.
        /// </summary>
        public int actionID => m_actionID;

        /// <summary>
        /// Create a new <see cref="RewiredAction"/> instance with the specified ID.
        /// </summary>
        /// <param name="actionID"></param>
        public RewiredAction(int actionID)
        {
            m_actionID = actionID;
        }

        public static implicit operator int(RewiredAction @this)
        {
            return @this.m_actionID;
        }

        public bool Equals(RewiredAction other)
        {
            return m_actionID == other.m_actionID;
        }

        public override bool Equals(object obj)
        {
            return obj is RewiredAction other && Equals(other);
        }

        public override int GetHashCode()
        {
            return actionID;
        }

        public static bool operator ==(RewiredAction left, RewiredAction right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(RewiredAction left, RewiredAction right)
        {
            return !left.Equals(right);
        }
    }
}
