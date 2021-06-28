using UnityEngine;

namespace NTL.Gameplay
{
    public class SpeedPowerup : TimerPowerup
    {
        [Space]
        [Header("Speed")]
        [SerializeField] private float speed;

        public override void PowerupStart(Collider col)
        {
            col.GetComponent<TankController>().AddSpeed(speed);
        }

        public override void PowerupFinish(Collider col)
        {
            col.GetComponent<TankController>().RemoveSpeed(speed);
        }
    }
}
