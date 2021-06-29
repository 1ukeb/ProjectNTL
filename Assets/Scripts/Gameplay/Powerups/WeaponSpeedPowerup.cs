using UnityEngine;

namespace NTL.Gameplay
{
    [CreateAssetMenu(menuName = "NTL/Powerups/Weapon Speed")]
    public class WeaponSpeedPowerup : PowerupSO
    {
        public float speedDecrease;

        public override void ApplyPowerup(TankEntity tank)
        {
            tank.GetComponent<TankWeaponController>().RemoveTimeBetweenShots(speedDecrease);
        }

        public override void RemovePowerup(TankEntity tank)
        {
            tank.GetComponent<TankWeaponController>().AddTimeBetweenShots(speedDecrease);
        }
    }
}
