using UnityEngine;

namespace NTL.Gameplay
{
    [CreateAssetMenu(menuName = "NTL/Powerups/Immune")]
    public class ImmunePowerup : TimedPowerupSO
    {
        public float immuneTime;

        public override void ApplyPowerup(TankEntity tank)
        {
            tank.GetComponent<TankHealth>().AddImmuneTime(immuneTime);
        }

        public override void RemovePowerup(TankEntity tank)
        {
            tank.GetComponent<TankHealth>().RemoveImmuneTime(immuneTime);
        }
    }
}
