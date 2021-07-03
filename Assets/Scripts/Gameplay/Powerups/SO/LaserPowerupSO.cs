using UnityEngine;

namespace NTL.Gameplay
{
    [CreateAssetMenu(menuName = "NTL/Powerups/Laser")]
    public class LaserPowerupSO : TimedPowerupSO
    {
        public override void ApplyPowerup(TankEntity tank)
        {
            tank.GetComponent<TankLaser>().AddLaser();
        }

        public override void RemovePowerup(TankEntity tank)
        {
            tank.GetComponent<TankLaser>().RemoveLaser();
        }
    }
}
