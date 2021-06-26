using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTools.Extensions;

namespace NTL.Spawning
{
    public class TankSpawner : MonoBehaviour
    {
        // use scriptable object factory
        [SerializeField] private GameObject tankPrefab;

        private List<Transform> tankSpawnTransforms = new List<Transform>();

        private void Start()
        {
            LoadTankSpawnTransforms();
        }

        // loads all tank spawn transforms in the scene and stores in list
        private void LoadTankSpawnTransforms()
        {
            GameObject[] spawnGameObjects = GameObject.FindGameObjectsWithTag("TankSpawnTransform");
            foreach (GameObject go in spawnGameObjects)
                tankSpawnTransforms.Add(go.transform);
        }

        // spawn a tank with string as key to control it
        public void SpawnWithKey(string key)
        {
            //tankSpawnTransform
        }
    }
}
