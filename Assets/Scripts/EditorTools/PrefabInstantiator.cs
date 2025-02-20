using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace EditorTools
{
    public class PrefabInstantiatorWindow : EditorWindow
    {
        // List of prefabs to choose from
        public List<GameObject> prefabs = new List<GameObject>();
        public Grid grid;
        public Transform parentObject;
        private bool isActive = false;

        [MenuItem("Tools/2D Prefab Instantiator")]
        public static void ShowWindow()
        {
            GetWindow<PrefabInstantiatorWindow>("2D Prefab Instantiator");
        }

        void OnGUI()
        {
            GUILayout.Label("Set Up Prefab Instantiation", EditorStyles.boldLabel);
            grid = (Grid)EditorGUILayout.ObjectField("Grid", grid, typeof(Grid), true);
            parentObject = (Transform)EditorGUILayout.ObjectField("Parent Object", parentObject, typeof(Transform), true);
            // Allow the user to set the number of prefabs
            int newCount = EditorGUILayout.IntField("Number of Prefabs", prefabs.Count);
            // Adjust the list size if needed
            while (newCount > prefabs.Count)
                prefabs.Add(null);
            while (newCount < prefabs.Count)
                prefabs.RemoveAt(prefabs.Count - 1);

            // Display an ObjectField for each prefab in the list
            for (int i = 0; i < prefabs.Count; i++)
            {
                prefabs[i] = (GameObject)EditorGUILayout.ObjectField("Prefab " + (i + 1), prefabs[i], typeof(GameObject), false);
            }

            GUILayout.Space(10);
            // Toggle the instantiation mode on and off
            if (!isActive)
            {
                if (GUILayout.Button("Start Instantiating"))
                {
                    isActive = true;
                    SceneView.duringSceneGui += OnSceneGUI;
                }
            }
            else
            {
                if (GUILayout.Button("Stop Instantiating"))
                {
                    isActive = false;
                    SceneView.duringSceneGui -= OnSceneGUI;
                }
            }
        }

        void OnSceneGUI(SceneView sceneView)
        {
            Event e = Event.current;
            // Listen for left mouse button click
            if (e.type == EventType.MouseDown && e.button == 0)
            {
                // Convert the mouse position to a world position.
                Vector3 worldPos = HandleUtility.GUIPointToWorldRay(e.mousePosition).origin;
                // For a 2D game, force z to 0
                worldPos.z = 0;

                // If at least one prefab exists in the list, choose one at random.
                if (prefabs.Count > 0)
                {
                    int randomIndex = Random.Range(0, prefabs.Count);
                    GameObject selectedPrefab = prefabs[randomIndex];
                    if (selectedPrefab != null)
                    {
                        GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(selectedPrefab, parentObject);
                        Undo.RegisterCreatedObjectUndo(instance, "Instantiate Prefab");
                        SpriteSortY[] sprites = instance.GetComponents<SpriteSortY>();
                        
                        Debug.Log(worldPos.x + " " + worldPos.y);
                        worldPos.x = snapNumber(worldPos.x, grid.cellSize.x, grid.gameObject.transform.position.x);
                        worldPos.y = snapNumber(worldPos.y, grid.cellSize.y, grid.gameObject.transform.position.y);
                        instance.transform.position = worldPos;
                        Debug.Log(worldPos.x + " " + worldPos.y);
                        
                        foreach (var sprite in sprites)
                        {
                            sprite.UpdateOrderInLayer((int)(sprite.gameObject.transform.position.y * -5.0f));
                        }
                    }
                }
                // Use the event so it isn't processed further
                e.Use();
            }
        }
        void OnDisable()
        {
            // Clean up the SceneView event if it was still registered
            SceneView.duringSceneGui -= OnSceneGUI;
        }

        private float snapNumber(float x, float stepSize, float offset)
        {
            x -= offset;
            if (x >= 0)
            {
                if (x == 0) x = 1;
                x = (Mathf.Ceil(x / stepSize) - 1) * stepSize + stepSize/2 + offset;
            }
            else if (x < 0)
                x = (Mathf.Floor(x / stepSize) + 1) * stepSize + stepSize/2 + offset;
            return x;
        }
    }
}