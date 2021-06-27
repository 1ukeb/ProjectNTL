using UnityEngine;

namespace NTL.Spawning
{
    [ExecuteAlways]
    public class TankSpawnTransform : MonoBehaviour
    {
        private void OnEnable() => TankSpawner.spawnTransforms.Add(this.transform);
        private void OnDisable() => TankSpawner.spawnTransforms.Remove(this.transform);
    }
}