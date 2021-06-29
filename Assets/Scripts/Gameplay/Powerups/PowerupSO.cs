using UnityEngine;

namespace NTL.Gameplay
{
    public class PowerupSO : ScriptableObject
    {
        public virtual void ApplyPowerup(TankEntity tank) { }
        public virtual void RemovePowerup(TankEntity tank) { }
    }
}
