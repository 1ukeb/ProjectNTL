using System.Collections.Generic;
using UnityEngine;

namespace NTL.Spawning
{
    [CreateAssetMenu(menuName = "NTL/Tank Settings")]
    public class TankSettingsSO : ScriptableObject
    {
        // list of colors for tank
        public List<Material> materials;
    }
}
