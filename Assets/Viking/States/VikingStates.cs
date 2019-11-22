using System;
using System.Linq;
using UnityEngine;

namespace Viking.States
{
    /// <summary>
    /// Viking states manager;
    /// Handles setting, getting, adding, removing, etc.
    /// </summary>
    public static class VikingStates
    {
        /// <summary>
        /// List of states.
        /// </summary>
        public static States states { get; private set; } = Resources.Load<States>("Resources/Viking/");

        /// <summary>
        /// Previous state; Used to restore the current state.
        /// </summary>
        public static State previous { get; private set; } = null;

        /// <summary>
        /// The current state.
        /// </summary>
        public static State current { get; private set; } = null;
        
        /// <summary>
        /// Set a new current state.
        /// </summary>
        /// <param name="state">State to set.</param>
        /// <param name="setPrevious">Optional: Set previous state as the current?</param>
        public static void SetState(State state, bool setPrevious = true)
        {
            if (setPrevious)
            {
                SetPrevious();
            }

            try
            {
                current = state;
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        /// <summary>
        /// Set a new current state.
        /// </summary>
        /// <param name="state">Name of state to set.</param>
        /// <param name="setPrevious">Optional: Set previous state as the current?</param>
        public static void SetState(string name, bool setPrevious = true)
        {
            if (setPrevious)
            {
                SetPrevious();
            }

            try
            {
                current = states.states.Find(s => s.name == name);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        /// <summary>
        /// Set a new current state.
        /// </summary>
        /// <param name="state">Index of state to set.</param>
        /// <param name="setPrevious">Optional: Set previous state as the current?</param>
        public static void SetState(int index, bool setPrevious = true)
        {
            if (setPrevious)
            {
                SetPrevious();
            }

            try
            {
                current = states.states.ElementAt(index);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
        
        /// <summary>
        /// Get the current state name.
        /// </summary>
        /// <returns>The current state; Empty if none.</returns>
        public static string GetCurrentState()
        {
            return current.name;
        }
        
        /// <summary>
        /// Get the current state.
        /// </summary>
        /// <param name="state">Returns the current state; Null if none.</param>
        public static void GetCurrentState(out State state)
        {
            try
            {
                state = current;
            }
            catch (Exception e)
            {
                Debug.LogException(e);

                state = null;
            }
        }

        /// <summary>
        /// Get the current state name.
        /// </summary>
        /// <param name="state">Returns the current state name; Empty if none.</param>
        public static void GetCurrentState(out string name)
        {
            try
            {
                name = current.name;
            }
            catch (Exception e)
            {
                Debug.LogException(e);

                name = "";
            }
        }

        /// <summary>
        /// Get the previous state name.
        /// </summary>
        /// <returns>The previous state; Empty if none.</returns>
        public static string GetPreviousState()
        {
            return previous.name;
        }

        /// <summary>
        /// Get the previous state.
        /// </summary>
        /// <param name="state">Returns the previous state; Null if none.</param>
        public static void GetPreviousState(out State state)
        {
            try
            {
                state = previous;
            }
            catch (Exception e)
            {
                Debug.LogException(e);

                state = null;
            }
        }

        /// <summary>
        /// Get the previous state name.
        /// </summary>
        /// <param name="state">Returns the previous state name; Empty if none.</param>
        public static void GetPreviousState(out string name)
        {
            try
            {
                name = previous.name;
            }
            catch (Exception e)
            {
                Debug.LogException(e);

                name = "";
            }
        }

        /// <summary>
        /// Add a new state.
        /// </summary>
        /// <param name="state">State to add.</param>
        public static void AddState(State state)
        {
            try
            {
                states.states.Add(state);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        /// <summary>
        /// Add a new state.
        /// </summary>
        /// <param name="state">Name of the state to add.</param>
        public static void AddState(string name)
        {
            try
            {
                states.states.Add(new State(name));
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        /// <summary>
        /// Remove a state.
        /// </summary>
        /// <param name="state">State to remove.</param>
        public static void RemoveState(State state)
        {
            try
            {
                states.states.Remove(state);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        /// <summary>
        /// Remove a state.
        /// </summary>
        /// <param name="state">Name of state to remove.</param>
        public static void RemoveState(string name)
        {
            try
            {
                states.states.Remove(states.states.Find(s => s.name == name));
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        /// <summary>
        /// Remove a state.
        /// </summary>
        /// <param name="state">Index of state to remove.</param>
        public static void RemoveState(int index)
        {
            try
            {
                states.states.RemoveAt(index);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        /// <summary>
        /// Get all states.
        /// </summary>
        /// <returns>States as array.</returns>
        public static State[] GetStates()
        {
            try
            {
                return states.states.ToArray();
            }
            catch (Exception e)
            {
                Debug.LogException(e);

                return null;
            }
        }

        /// <summary>
        /// Get all state names.
        /// </summary>
        /// <returns>State names as array.</returns>
        public static string[] GetStateNames()
        {
            try
            {
                return states.states.Select(s => s.name).ToArray();
            }
            catch (Exception e)
            {
                Debug.LogException(e);

                return null;
            }
        }

        /// <summary>
        /// Get the first state.
        /// </summary>
        /// <returns>Null if none.</returns>
        public static State GetFirst()
        {
            try
            {
                return states.states.First();
            }
            catch (Exception e)
            {
                Debug.Log(e);

                return null;
            }
        }

        /// <summary>
        /// Get the first state name.
        /// </summary>
        /// <param name="name">Returns state name; Empty if none.</param>
        public static void GetFirst(out string name)
        {
            try
            {
                name = states.states.First().name;
            }
            catch (Exception e)
            {
                Debug.Log(e);

                name = "";
            }
        }

        /// <summary>
        /// Get the last state.
        /// </summary>
        /// <returns>Null if none.</returns>
        public static State GetLast()
        {
            try
            {
                return states.states.Last();
            }
            catch (Exception e)
            {
                Debug.Log(e);

                return null;
            }
        }

        /// <summary>
        /// Get the last state name.
        /// </summary>
        /// <param name="name">Returns state name; Empty if none.</param>
        public static void GetLast(out string name)
        {
            try
            {
                name = states.states.Last().name;
            }
            catch (Exception e)
            {
                Debug.Log(e);

                name = "";
            }
        }

        /// <summary>
        /// Check if a state exits.
        /// </summary>
        /// <param name="state">State to check.</param>
        /// <returns>True if exists.</returns>
        public static bool StateExists(State state)
        {
            try
            {
                return states.states.Contains(state);
            }
            catch (Exception e)
            {
                Debug.LogException(e);

                return false;
            }
        }

        /// <summary>
        /// Check if a state exits.
        /// </summary>
        /// <param name="state">Name of state to check.</param>
        /// <returns>True if exists.</returns>
        public static bool StateExists(string name)
        {
            try
            {
                return states.states.Any(s => s.name == name);
            }
            catch (Exception e)
            {
                Debug.LogException(e);

                return false;
            }
        }
        
        /// <summary>
        /// Restore the current state from the previous.
        /// </summary>
        public static void RestoreState()
        {
            try
            {
                current = previous;
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
        
        /// <summary>
        /// Clear the previous state.
        /// </summary>
        public static void ClearPrevious()
        {
            previous = null;
        }

        /// <summary>
        /// Clear the current state.
        /// </summary>
        public static void ClearCurrent()
        {
            current = null;
        }

        /// <summary>
        /// Remove all states.
        /// </summary>
        public static void ClearAll()
        {
            states.states.Clear();
        }
        
        /// <summary>
        /// Set the previous state as the current.
        /// </summary>
        public static void SetPrevious()
        {
            try
            {
                previous = current;
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
        
        /// <summary>
        /// Set a specific previous state.
        /// </summary>
        /// <param name="state">State to set.</param>
        public static void SetPrevious(State state)
        {
            try
            {
                previous = state;
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        /// <summary>
        /// Set a specific previous state.
        /// </summary>
        /// <param name="state">Name of state to set.</param>
        public static void SetPrevious(string state)
        {
            try
            {
                previous = states.states.Find(s => s.name == state);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}
