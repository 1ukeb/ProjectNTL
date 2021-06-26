using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NTL.Gameplay
{
    public class PlayerFup : MonoBehaviour
    {
        // bullet spawned when shooting
        [SerializeField] private GameObject bulletPrefab;
        // spawn location of bullet when shooting
        [SerializeField] private Transform attackTransform;
        // speed of bullet
        [SerializeField] private float bulletSpeed;

        // shoots a bulletPrefab from attack transform using bullet speed
        // (dont worry about rotation)
        public void Shoot()
        {

        }
    }
}
