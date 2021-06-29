using UnityEngine;
using NTL.Spawning;
using NTL.Camera;

namespace NTL.Gameplay
{
    public class TankEntity : MonoBehaviour
    {
        private void OnEnable()
        {
            TankSpawner.activeTanks.Add(GetComponent<TankController>());
            CameraController.targets.Add(this.transform);
        }

        private void OnDisable()
        {
            TankSpawner.activeTanks.Remove(GetComponent<TankController>());
            CameraController.targets.Remove(this.transform);
        }
    }
}
