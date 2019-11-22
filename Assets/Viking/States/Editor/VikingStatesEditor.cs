using UnityEditor;
using UnityEngine;

namespace Viking.States
{
    /// <summary>
    /// VikingStates Editor; Visually add, edit, and delete states.
    /// </summary>
    public class VikingStatesEditor : EditorWindow
    {
        /// <summary>
        /// Editor window.
        /// </summary>
        private static VikingStatesEditor window;
        
        /// <summary>
        /// Path to the states.
        /// </summary>
        private static string path = "Assets/Resources/Viking";

        /// <summary>
        /// Reference to the states.
        /// </summary>
        private static States states;

        /// <summary>
        /// Scroll view values for the editor window.
        /// </summary>
        private Vector2 scroll;

        /// <summary>
        /// Initializes the Viking States editor.
        /// </summary>
        [MenuItem("Viking/States")]
        static void Init()
        {
            window = GetWindow<VikingStatesEditor>(true, "Viking States");

            CheckFolder();

            CheckStates();

            window.Show();
        }

        /// <summary>
        /// Check if Resources/Viking/ path exists;
        /// Creates folder if not.
        /// </summary>
        private static void CheckFolder()
        {
            if (!AssetDatabase.IsValidFolder("Assets/Resources"))
            {
                AssetDatabase.CreateFolder("Assets", "Resources");
                AssetDatabase.SaveAssets();
            }

            if (!AssetDatabase.IsValidFolder(path))
            {
                AssetDatabase.CreateFolder("Assets/Resources", "Viking");
                AssetDatabase.SaveAssets();
            }
        }

        /// <summary>
        /// Check if states exist; Create if not.
        /// </summary>
        private static void CheckStates()
        {
            states = AssetDatabase.LoadAssetAtPath<States>(path + "/" + "VikingStates.asset");

            if (!states)
            {
                Debug.LogWarning("Could not find states... Creating.");
                CreateStates();
            }
        }

        /// <summary>
        /// Create Viking States.
        /// </summary>
        private static void CreateStates()
        {
            States newStates = CreateInstance<States>();

            AssetDatabase.CreateAsset(newStates, path + "/" + "VikingStates.asset");
            AssetDatabase.SaveAssets();

            states = newStates;

            /*
                EditorUtility.FocusProjectWindow();
                Selection.activeObject = states;
            */
        }

        /// <summary>
        /// When the editor window loses focus.
        /// </summary>
        private void OnLostFocus()
        {
            window.Close();
        }

        /// <summary>
        /// When the window is destroyed.
        /// </summary>
        private void OnDestroy()
        {
            AssetDatabase.SaveAssets();
        }

        /// <summary>
        /// Renders the window.
        /// </summary>
        private void OnGUI()
        {
            if (!states)
            {
                return;
            }

            scroll = EditorGUILayout.BeginScrollView(scroll);

            // display each state
            foreach (State state in states.states)
            {
                EditorGUILayout.BeginHorizontal();

                // name of the state
                state.name = EditorGUILayout.TextField(state.name, GUILayout.ExpandWidth(true));
                
                // delete button for the state
                if (GUILayout.Button("X", GUILayout.Width(32)))
                {
                    states.states.Remove(state);
                    break;
                }

                EditorGUILayout.EndHorizontal();
            }

            EditorGUILayout.EndScrollView();

            GUILayout.FlexibleSpace();
            
            // add a new state button
            if (GUILayout.Button("Add", GUILayout.ExpandWidth(true)))
            {
                states.states.Add(new State());
            }
        }
    }
}
