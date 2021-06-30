using UnityEngine;

namespace NTL.Gameplay
{
    [CreateAssetMenu(menuName = "NTL/Powerups/Burst Shot")]
    public class BurstShotPowerup : TimedPowerupSO
    {
        public int additionalShots;

        public override void ApplyPowerup(TankEntity tank)
        {
            tank.GetComponent<TankWeapon>().AddShootCounter(additionalShots);
        }

        public override void RemovePowerup(TankEntity tank)
        {
            tank.GetComponent<TankWeapon>().RemoveShootCounter(additionalShots);
        }
    }
}
