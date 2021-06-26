using UnityEngine;

namespace NTL.Physics
{
    [RequireComponent(typeof(Rigidbody))]
    public class RigidbodyController : MonoBehaviour
    {
        [SerializeField] new private Rigidbody rigidbody;

        public Vector3 FacingDirection => transform.forward;

        // setup component
        private void Awake()
        {
            if (!rigidbody)
                rigidbody = GetComponent<Rigidbody>();
        }

        // move towards where tank is facing
        public void MoveForward(float speed) => rigidbody.velocity = FacingDirection * speed;

        // rotate on z axis around self
        public void Rotate(float speed) => transform.Rotate(0, speed, 0, Space.Self);
    }
}
