using System.Collections;
using UnityEngine;

namespace NTL.Gameplay
{
    public class Powerup : MonoBehaviour
    {
        [Space]
        [Header("Powerup")]
        // the powerup to apply
        [SerializeField] protected PowerupSO powerupSO;

        [Space]
        [Header("Particle")]
        [SerializeField] protected GameObject particle;

        public virtual void OnTriggerEnter(Collider col)
        {
            if (!col.CompareTag("Player"))
                return;

            // if powerup is timer type, start corotuine
            if (powerupSO is TimedPowerupSO)
                StartCoroutine(ApplyPowerupTimer(col));
            // else apply powerup regularly
            else
                ApplyPowerup(col);

            // if particle, spawn it
            if (particle)
                Instantiate(particle, transform.position, Quaternion.identity);

            // disables gfx and collider
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
        }

        // apply and remove powerup from time
        private IEnumerator ApplyPowerupTimer(Collider col)
        {
            ApplyPowerup(col);
            yield return new WaitForSeconds(((TimedPowerupSO)powerupSO).time);
            RemovePowerup(col);
        }

        // apply powerup (col is player)
        public virtual void ApplyPowerup(Collider col)
        {
            powerupSO.ApplyPowerup(col.GetComponent<TankEntity>());
        }

        // remove powerup
        public virtual void RemovePowerup(Collider col)
        {
            if (col)
                powerupSO.RemovePowerup(col.GetComponent<TankEntity>());
        }
    }
}
