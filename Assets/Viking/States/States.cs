using System.Collections.Generic;
using UnityEngine;

namespace Viking.States
{
    /// <summary>
    /// Collection of states.
    /// </summary>
    [System.Serializable]
    public class States : ScriptableObject
    {
        /// <summary>
        /// List of states.
        /// </summary>
        public List<State> states = new List<State>();
    }
}
