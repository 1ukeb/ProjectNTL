using UnityEngine;
using UnityEngine.Events;

namespace NTL.Gameplay
{
    public class Destructible : MonoBehaviour
    {
        public delegate void DestructEvent();
        // when this is destructed
        public DestructEvent OnDestruct;

        public UnityEvent unityEvent;

        //public virtual void OnTriggerEnter(Collider col)
        //{
        //    // if bullet collision, destruct
        //    if (IsValidCollision(col))
        //        Destruct();
        //}

        //public virtual bool IsValidCollision(Collider col)
        //{
        //    return col.CompareTag("Bullet");
        //}

        public virtual void Destruct()
        {
            OnDestruct?.Invoke();
            unityEvent?.Invoke();
        }
    }
}
