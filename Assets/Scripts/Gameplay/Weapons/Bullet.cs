using UnityEngine;

namespace NTL.Gameplay
{
    public class Bullet : MonoBehaviour
    {
        // tank weapon that fired this bullet
        [HideInInspector] public TankWeapon tankWeapon;

        public GameObject explosionParticle;

        public virtual void OnTriggerEnter(Collider col)
        {
            // hit player
            if (col.CompareTag("Player"))
            {
                // If tank we hit is the one that fired this bullet, return
                if (col.GetComponent<TankWeapon>() == tankWeapon)
                    return;

                HandlePlayerCollision(col);
                return;
            }

            // hit other collision
            HandleCollision(col);
        }

        public virtual void HandleCollision(Collider col)
        {
            Instantiate(explosionParticle, transform.position, Quaternion.identity);
            DestroyBullet();
        }

        public virtual void HandlePlayerCollision(Collider col)
        {
            // deal damage to player
            col.GetComponent<TankHealth>().TakeDamage(1);

            DestroyBullet();
        }

        public virtual void DestroyBullet()
        {
            Destroy(gameObject);
        }
    }
}
