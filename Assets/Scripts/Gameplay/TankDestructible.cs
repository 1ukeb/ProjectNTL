using UnityEngine;

namespace NTL.Gameplay
{
    public class TankDestructible : Destructible
    {
        public override bool IsValidCollision(Collider col)
        {
            // return if is bullet tag and bullet is not from this tank
            return base.IsValidCollision(col);
        }
    }
}
