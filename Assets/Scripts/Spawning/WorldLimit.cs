using UnityEngine;
using NTL.Gameplay;

namespace NTL.Spawning
{
    public class WorldLimit : MonoBehaviour
    {
        private void OnTriggerEnter(Collider col)
        {
            if (col.CompareTag("Player"))
            {
                // kill tank that has entered collider
                col.GetComponent<TankHealth>().Die();
            }
            else
                Destroy(col.gameObject);
        }
    }
}
