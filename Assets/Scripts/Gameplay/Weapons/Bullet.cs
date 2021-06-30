using UnityEngine;

namespace NTL.Gameplay
{
    public class Bullet : MonoBehaviour
    {
        // tank weapon that fired this bullet
        [HideInInspector] public TankWeapon tankWeapon;

        public GameObject explosionParticle;
        public GameObject trailParticle;

        public ParticleSystem[] sys;

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

            if (col.CompareTag("Bullet"))
            {
                // if bullet collided with bullet from same tank
                if (col.GetComponent<Bullet>().tankWeapon == tankWeapon)
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
            // stop all particles from playing
            foreach (ParticleSystem s in sys)
                s.Stop();

            // remove particle transform parent
            trailParticle.transform.SetParent(null);
            // add component to destroy particles after they are done 
            //trailParticle.AddComponent<DestroyParticles>();
            DestroySeconds ds = trailParticle.AddComponent<DestroySeconds>();
            ds.SetSeconds(3);

            Destroy(gameObject);
        }
    }
}
