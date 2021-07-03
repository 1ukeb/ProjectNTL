using UnityEngine;
using TinyTools.Extensions;

namespace NTL.Spawning
{
    public class TankRandomColor : MonoBehaviour
    {
        [Space]
        [Header("Settings Asset")]
        [SerializeField] private TankSettingsSO tankSettingsSO;

        [Space]
        [Header("Renderers")]
        [SerializeField] private Renderer[] renderers;

        private void Start()
        {
            Material mat = tankSettingsSO.materials.Random();

            if (renderers.Length <= 0)
                return;

            // apply material to each renderer
            foreach (Renderer rend in renderers)
                rend.material = mat;
        }
    }
}
