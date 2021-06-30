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

        // spread shot enabled?
        private int spreadShotCounter = 0;
        private int spreadAngle = 15;
        public void AddSpreadShot(int amount) => spreadShotCounter += amount;
        public void RemoveSpreadShot(int amount) => spreadShotCounter -= amount;

        private float timeBetweenShots = 0.1f;

        // shoots bullet forward
        public void Shoot()
        {
            // shoot bullet
            ShootSingle();

            // spread shot powerup, shoot bullets at angle
            ShootAngled();

            // try to shoot multiple if counter > 0
            ShootMultiple();
        }

        private void AddBulletVelocity(GameObject bullet)
        {
            // add speed to bullet
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

            // set bullets weapon that fired it to this
            bullet.GetComponent<Bullet>().tankWeapon = this;
        }

        // shoots 1 bullet
        private void ShootSingle()
        {
            // spawn bullet
            GameObject bullet = Instantiate(bulletPrefab, fireTransform.position, fireTransform.rotation);

            AddBulletVelocity(bullet);
        }

        #region Shoot Angled
        private void ShootAngled()
        {
            if (spreadShotCounter > 0)
            {
                int angle = (spreadShotCounter * spreadAngle) / 2;
                for (int i = 0; i < spreadShotCounter; i++)
                {
                    // skip shooting directly forward
                    if (angle == 0)
                        angle -= spreadAngle;

                    ShootAtAngle(angle);
                    angle -= spreadAngle;
                }
            }
        }

        // shoot bullets at an angle (y)
        private void ShootAtAngle(float rotation)
        {
            Vector3 rot = fireTransform.eulerAngles;
            // rotate new angle on y
            rot.y += rotation;
            GameObject bullet = Instantiate(bulletPrefab, fireTransform.position, Quaternion.Euler(rot));

            AddBulletVelocity(bullet);
        }
        #endregion

        #region Shoot Multiple
        private void ShootMultiple()
        {
            if (shootCounter == 0)
                return;

            float timer = timeBetweenShots;

            for (int i = 0; i < shootCounter; i++)
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
            ShootSingle();
        }
        #endregion
    }
}
