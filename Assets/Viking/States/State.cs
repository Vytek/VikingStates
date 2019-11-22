namespace Viking.States
{
    /// <summary>
    /// State base.
    /// </summary>
    [System.Serializable]
    public class State
    {
        /// <summary>
        /// Name of the state.
        /// </summary>
        public string name = "New State";

        /// <summary>
        /// Initialize a new state.
        /// </summary>
        public State() { }

        /// <summary>
        /// Initialize a new state.
        /// </summary>
        /// <param name="name">Desired state name.</param>
        public State(string name)
        {
            this.name = name;
        }
    }
}
