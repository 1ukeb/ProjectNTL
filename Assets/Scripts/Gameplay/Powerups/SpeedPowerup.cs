using UnityEngine;

namespace NTL.Gameplay
{
    [CreateAssetMenu(menuName = "NTL/Powerups/Speed")]
    public class SpeedPowerup : PowerupSO
    {
        public float speed;

        public override void ApplyPowerup(TankEntity tank)
        {
            tank.GetComponent<TankController>().AddSpeed(speed);
        }

        public override void RemovePowerup(TankEntity tank)
        {
            tank.GetComponent<TankController>().RemoveSpeed(speed);
        }
    }
}
