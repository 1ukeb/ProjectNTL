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

        // shoots bullet forward
        public void Shoot()
        {
            // spawn bullet
            GameObject bullet = Instantiate(bulletPrefab, fireTransform.position, fireTransform.rotation);

            // add speed to bullet
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

            // set bullets weapon that fired it to this
            bullet.GetComponent<Bullet>().tankWeapon = this;
        }
    }
}
