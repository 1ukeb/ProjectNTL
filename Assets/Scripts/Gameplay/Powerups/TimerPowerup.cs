using System;
using System.Collections;
using UnityEngine;

namespace NTL.Gameplay
{
    public class TimerPowerup : Powerup
    {
        [Space]
        [Header("Timer")]
        [SerializeField] protected float powerupDuration;

        public override void ApplyPowerup(Collider col) => StartCoroutine(PowerupTimer(col));

        private IEnumerator PowerupTimer(Collider col)
        {
            base.ApplyPowerup(col);

            yield return new WaitForSeconds(powerupDuration);

            base.RemovePowerup(col);
        }
    }
}
