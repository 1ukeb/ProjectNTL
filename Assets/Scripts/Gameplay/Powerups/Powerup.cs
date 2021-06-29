using UnityEngine;

namespace NTL.Gameplay
{
    public class Powerup : MonoBehaviour
    {
        [Space]
        [Header("Powerup")]
        [SerializeField] protected PowerupSO powerupSO;

        [Space]
        [Header("Particle")]
        [SerializeField] protected GameObject particle;

        public virtual void OnTriggerEnter(Collider col)
        {
            if (!col.CompareTag("Player"))
                return;

            ApplyPowerup(col);

            if (particle)
                Instantiate(particle, transform.position, Quaternion.identity);

            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
        }

        // apply power up (col is player)
        public virtual void ApplyPowerup(Collider col)
        {
            powerupSO.ApplyPowerup(col.GetComponent<TankEntity>());
        }

        public virtual void RemovePowerup(Collider col)
        {
            powerupSO.RemovePowerup(col.GetComponent<TankEntity>());
        }
    }
}
