using System;
using System.Collections;
using UnityEngine;

namespace NTL.Gameplay
{
    public class TimerPowerup : Powerup
    {
        public event Action powerupStarted;
        public event Action powerupFinished;

        [Space]
        [Header("Timer")]
        [SerializeField] protected float powerupDuration;

        public override void ApplyPowerup(Collider col)
        {
            StartCoroutine(PowerupTimer(col));
        }

        private IEnumerator PowerupTimer(Collider col)
        {
            powerupStarted?.Invoke();
            PowerupStart(col);

            yield return new WaitForSeconds(powerupDuration);

            powerupFinished?.Invoke();
            PowerupFinish(col);
        }

        public virtual void PowerupStart(Collider col) { }
        public virtual void PowerupFinish(Collider col) { }
    }
}
