using UnityEngine;

namespace NTL.Gameplay
{
    [CreateAssetMenu(menuName = "NTL/Powerups/Immune")]
    public class ImmunePowerup : TimedPowerupSO
    {
        public override void ApplyPowerup(TankEntity tank)
        {
            tank.GetComponent<TankHealth>().AddImmune();
        }

        public override void RemovePowerup(TankEntity tank)
        {
            tank.GetComponent<TankHealth>().RemoveImmune();
        }
    }
}
