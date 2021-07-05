using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NTL.Spawning;
using NTL.App;
using TinyTools.Extensions;

namespace NTL.Gameplay
{
    [CreateAssetMenu(menuName = "NTL/Powerups/Seeking Bullet")]
    public class SeekingBulletPowerupSO : PowerupSO
    {
        public int bulletAmount;
        public GameObject bulletPrefab;
        public float bulletRisingSpeed;
        public float bulletSpeed;

        public override void ApplyPowerup(TankEntity tank)
        {
            // create list of targets excluding this tank
            List<TankController> targets = TankSpawner.activeTanks;
            targets.Remove(tank.GetComponent<TankController>());

            // if no targets, return
            if (targets.Count <= 0)
                return;

            for (int i = 0; i < bulletAmount; i++)
            {
                // if ran out of targets, return
                if (targets.Count <= 0)
                    break;

                // send seeking bullet at random target
                AppManager.Singleton.StartCoroutine(SeekingBullet(tank, targets.RemoveRandom().transform));
            }
        }

        private IEnumerator SeekingBullet(TankEntity tank, Transform target)
        {
            // set target is targeted indicator
            target.GetComponent<TankHealth>().AddTargeted();

            Bullet bullet = Instantiate(bulletPrefab, tank.transform.position + Vector3.up, Quaternion.identity).GetComponent<Bullet>();
            bullet.tankWeapon = tank.GetComponent<TankWeapon>();
            bullet.tankTarget = target;

            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.velocity = Vector3.up * bulletRisingSpeed;

            yield return new WaitForSeconds(0.5f);

            // if tank died during wait time
            if (target == null)
                yield break;

            bullet.transform.LookAt(target.position + target.transform.forward);
            bulletRigidbody.velocity = bullet.transform.forward * bulletSpeed;
        }
    }
}
