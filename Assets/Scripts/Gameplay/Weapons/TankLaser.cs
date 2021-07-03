using System.Collections;
using UnityEngine;

namespace NTL.Gameplay
{
    public class TankLaser : MonoBehaviour
    {
        [Space]
        [Header("Components")]
        [SerializeField] private Transform fireTransform;
        [SerializeField] private LineRenderer lineRenderer;

        [Space]
        [Header("Settings")]
        [SerializeField] private float length;
        [SerializeField] private int damage;
        [SerializeField] private float tickSpeed = 0.1f;
        [SerializeField] private LayerMask hitLayer;

        [Space]
        [Header("Particles")]
        [SerializeField] private GameObject damageParticle;

        private BoolStack stack = new BoolStack();
        private Coroutine tickCoroutine;

        public void AddLaser() => SetLaser(stack.Add());
        public void RemoveLaser() => SetLaser(stack.Remove());

        private void SetLaser(bool value)
        {
            // enable line renderer
            lineRenderer.enabled = value;

            if (value)
                tickCoroutine = StartCoroutine(Tick());
            else
                StopCoroutine(tickCoroutine);
        }

        private bool LaserRaycast(out RaycastHit hit)
        {
            return UnityEngine.Physics.Raycast(fireTransform.position, fireTransform.forward, out hit, length, hitLayer);
        }

        private void Update()
        {
            // if renderer enabled
            if (lineRenderer.enabled)
            {
                RaycastHit hit;
                if (LaserRaycast(out hit))
                {
                    lineRenderer.SetPosition(0, fireTransform.position);
                    lineRenderer.SetPosition(1, hit.point);
                    //Instantiate(damageParticle, hit.point, Quaternion.identity);
                }
                else
                {
                    lineRenderer.SetPosition(0, fireTransform.position);
                    lineRenderer.SetPosition(1, fireTransform.position + fireTransform.forward * length);
                }
            }
        }

        // laser damage tick
        private IEnumerator Tick()
        {
            yield return new WaitForSeconds(tickSpeed);

            RaycastHit hit;
            if (LaserRaycast(out hit))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    hit.collider.GetComponent<TankHealth>().TakeDamage(damage);
                    Instantiate(damageParticle, hit.point, Quaternion.identity);
                }
            }

            tickCoroutine = StartCoroutine(Tick());
        }
    }
}
