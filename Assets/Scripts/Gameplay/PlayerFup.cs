using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NTL.Gameplay
{
    public class PlayerFup : MonoBehaviour
    {
        // bullet spawned when shooting
        [SerializeField]
        private GameObject bulletPrefab;

        // spawn location of bullet when shooting
        [SerializeField]
        private Transform attackTransform;

        // speed of bullet
        [SerializeField]
        private float bulletSpeed;

        [SerializeField]
        private Transform firePoint;

        // shoots a bulletPrefab from attack transform using bullet speed
        // (dont worry about rotation)
        public void Shoot()
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
        }

        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
    }
}
