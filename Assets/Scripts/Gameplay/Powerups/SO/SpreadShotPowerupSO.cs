using UnityEngine;

namespace NTL.Gameplay
{
    [CreateAssetMenu(menuName = "NTL/Powerups/Spread Shot")]
    public class SpreadShotPowerupSO : TimedPowerupSO
    {
        // amount of additional bullets
        public int additionalShots;

        public override void ApplyPowerup(TankEntity tank)
        {
            tank.GetComponent<TankWeapon>().AddSpreadShot(additionalShots);
        }

        public override void RemovePowerup(TankEntity tank)
        {
            tank.GetComponent<TankWeapon>().RemoveSpreadShot(additionalShots);
        }
    }
}
