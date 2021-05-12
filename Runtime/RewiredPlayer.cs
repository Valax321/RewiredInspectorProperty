using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Valax321.RewiredActionProperty
{
    /// <summary>
    /// Wrapper for a Rewired player ID.
    /// </summary>
    [System.Serializable]
    public struct RewiredPlayer : IEquatable<RewiredPlayer>
    {
        [SerializeField]
        [FormerlySerializedAs("m_actionID")]
        private int m_playerID;

        /// <summary>
        /// The ID associated with this player.
        /// </summary>
        [System.Obsolete("Use playerID instead")]
        public int actionID => m_playerID;

        /// <summary>
        /// The ID associated with this player.
        /// </summary>
        public int playerID => m_playerID;

        /// <summary>
        /// Create a new <see cref="RewiredPlayer"/> instance with the specified ID.
        /// </summary>
        /// <param name="playerID"></param>
        public RewiredPlayer(int playerID)
        {
            m_playerID = playerID;
        }

        public static implicit operator int(RewiredPlayer @this)
        {
            return @this.m_playerID;
        }

        public bool Equals(RewiredPlayer other)
        {
            return m_actionID == other.m_actionID;
        }

        public override bool Equals(object obj)
        {
            return obj is RewiredPlayer other && Equals(other);
        }

        public override int GetHashCode()
        {
            return actionID;
        }

        public static bool operator ==(RewiredPlayer left, RewiredPlayer right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(RewiredPlayer left, RewiredPlayer right)
        {
            return !left.Equals(right);
        }
    }
}
