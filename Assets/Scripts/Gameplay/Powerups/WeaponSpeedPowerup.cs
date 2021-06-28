using UnityEngine;

namespace NTL.Gameplay
{
    public class WeaponSpeedPowerup : TimerPowerup
    {
        [Space]
        [Header("Weapon Speed")]
        [SerializeField] private float speedDecrease;

        public override void PowerupStart(Collider col)
        {
            col.GetComponent<TankWeaponController>().RemoveTimeBetweenShots(speedDecrease);
            UnityEngine.Debug.Log("Dec shot time");
        }

        public override void PowerupFinish(Collider col)
        {
            col.GetComponent<TankWeaponController>().AddTimeBetweenShots(speedDecrease);
        }
    }
}
