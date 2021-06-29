using System.Collections;
using UnityEngine;

namespace NTL.Gameplay
{
    public class TankWeapon : MonoBehaviour
    {
        [Space]
        [Header("Bullet")]
        // bullet spawned when shooting
        [SerializeField] private GameObject bulletPrefab;
        // speed of bullet
        [SerializeField] private float bulletSpeed;
        // transform of bullet fire
        [SerializeField] private Transform fireTransform;

        private int shootCounter = 0;
        public void AddShootCounter(int amount) => shootCounter += amount;
        public void RemoveShootCounter(int amount) => shootCounter -= amount;

        private float timeBetweenShots = 0.1f;

        // shoots bullet forward
        public void Shoot()
        {
            // shoot bullet
            ShootBullet();

            // try to shoot multiple
            ShootMultiple(shootCounter);
        }

        // shoots 1 bullet
        private void ShootBullet()
        {
            // spawn bullet
            GameObject bullet = Instantiate(bulletPrefab, fireTransform.position, fireTransform.rotation);

            // add speed to bullet
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

            // set bullets weapon that fired it to this
            bullet.GetComponent<Bullet>().tankWeapon = this;
        }

        private void ShootMultiple(int amount)
        {
            if (amount == 0)
                return;

            float timer = timeBetweenShots;

            for (int i = 0; i < amount; i++)
            {
                ShootDelay(timer);
                timer += timeBetweenShots;
            }
        }

        private void ShootDelay(float delay)
        {
            StartCoroutine(ShootDelayTimer(delay));
        }

        private IEnumerator ShootDelayTimer(float delay)
        {
            yield return new WaitForSeconds(delay);
            ShootBullet();
        }
    }
}
