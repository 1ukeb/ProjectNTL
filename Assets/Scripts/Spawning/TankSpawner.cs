using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTools.Extensions;
using NTL.Gameplay;
using NTL.Input;

#if UNITY_EDITOR
using UnityEditor;
#endif

#region Old
//private void Start()
//{
//    LoadTankSpawnTransforms();
//}

//// loads all tank spawn transforms in the scene and stores in list
//private void LoadTankSpawnTransforms()
//{
//    // find all gameobjects with tag
//    GameObject[] spawnGameObjects = GameObject.FindGameObjectsWithTag("TankSpawnTransform");

//    // add all gameobject tags to spawn list
//    foreach (GameObject go in spawnGameObjects)
//        spawnTransforms.Add(go.transform);

//    // populate round robin transforms with all spawn points
//    PopulateRoundRobinTankTransforms();
//}
#endregion

namespace NTL.Spawning
{
    public class TankSpawner : MonoBehaviour
    {
        // spawn mode
        [SerializeField] private SpawnMode spawnMode;

        // use scriptable object factory
        [SerializeField] private GameObject tankPrefab;

        // list of all tank spawn transforms
        public static List<Transform> spawnTransforms = new List<Transform>();

        // list of open tank spawn transforms
        private List<Transform> openSpawnTransforms = new List<Transform>();

        // list of active tanks
        public static List<TankController> activeTanks = new List<TankController>();

        private void Start()
        {
            // handle input event
            InputManager.OnInput += SpawnWithKey;
        }

        private void PopulateRoundRobinTankTransforms()
        {
            // if round robin list empty, repopulate
            openSpawnTransforms = new List<Transform>(spawnTransforms);
        }

        // Get a tank spawn position from list based on spawn mode
        public Vector3 GetTankSpawnPosition()
        {
            Vector3 position = Vector3.zero;
            switch (spawnMode)
            {
                case SpawnMode.Random:

                    // return random transform position
                    position = openSpawnTransforms.Random().position;
                    return position;

                case SpawnMode.RandomRoundRobin:

                    // if round robin list empty, repopulate
                    if (openSpawnTransforms.Count <= 0)
                        PopulateRoundRobinTankTransforms();

                    // get random transform from round robin list
                    position = openSpawnTransforms.RemoveRandom().position;

                    return position;

                case SpawnMode.RoundRobin:

                    if (openSpawnTransforms.Count <= 0)
                        PopulateRoundRobinTankTransforms();

                    // get transform from end of round robin list
                    position = openSpawnTransforms[openSpawnTransforms.Count - 1].position;

                    // remove transfrom from end of list
                    openSpawnTransforms.RemoveAt(openSpawnTransforms.Count - 1);
                    return position;

                default:

                    UnityEngine.Debug.LogError("Invalid SpawnMode.");
                    return position;
            }
        }

        // returns true if already an active tank with this key
        public bool IsActiveTank(string key)
        {
            // create list of tanks with input key already registered
            List<TankController> matchingTanks = activeTanks.FindAll(k => k.key == key);

            // return if 1 or more tanks
            return matchingTanks.Count != 0;
        }

        // spawn a tank with string as key to control it
        public void SpawnWithKey(string key)
        {
            // if tank already active, return
            if(IsActiveTank(key))
                return;

            // create list of tanks with input key already registered
            List<TankController> matchingTanks = activeTanks.FindAll(k => k.key == key);
            // if already tank with input key, return
            if (matchingTanks.Count != 0)
                return;

            // spawn tank
            TankController tankController = Instantiate(tankPrefab, GetTankSpawnPosition(), Quaternion.identity)
                .GetComponent<TankController>();

            // set key of tank
            tankController.key = key;
        }

        #region Gizmos
#if UNITY_EDITOR
        // Draw gizmos to all spawn transforms
        private void OnDrawGizmosSelected()
        {
            foreach (Transform spawnTransform in spawnTransforms)
            {
                Vector3 managerPos = transform.position;
                Vector3 spawnPos = spawnTransform.position;
                float halfHeight = (managerPos.y - spawnPos.y) * 0.5f;
                Vector3 offset = Vector3.up * halfHeight;

                Handles.DrawBezier(
                    managerPos,
                    spawnPos,
                    managerPos - offset,
                    spawnPos + offset,
                    Color.white,
                    EditorGUIUtility.whiteTexture,
                    1f
                    );
            }
        }
#endif
        #endregion
    }
}
