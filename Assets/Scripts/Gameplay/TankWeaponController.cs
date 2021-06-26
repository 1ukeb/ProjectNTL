using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NTL.Gameplay
{
    public class TankWeaponController : MonoBehaviour
    {
        [SerializeField] private PlayerFup theFupster;
        [SerializeField] private float timeBetweenShots;

        private Coroutine shootCoroutine;

        private void Start()
        {
            EnableShooting();
        }

        // turns repeat shooting on
        private void EnableShooting()
        {
            shootCoroutine = StartCoroutine(ShootTimer());
        }

        // turns repeat shooting off
        private void DisableShooting()
        {
            StopCoroutine(shootCoroutine);
        }

        private IEnumerator ShootTimer()
        {
            yield return new WaitForSeconds(timeBetweenShots);
            Debug.Log("Shooting");

            shootCoroutine = StartCoroutine(ShootTimer());
        }
    }
}
