using UnityEngine;

namespace NTL.Gameplay
{
    public class TankDestructible : Destructible
    {

        [SerializeField]
        private GameObject explosionPrefab;
        public override bool IsValidCollision(Collider col)
        {
            // return if is bullet tag and bullet is not from this tank
            return base.IsValidCollision(col);
        }

        public override void Destruct()
      {
          Instantiate(explosionPrefab, transform.position, Quaternion.identity);
      }
        
    }
}
