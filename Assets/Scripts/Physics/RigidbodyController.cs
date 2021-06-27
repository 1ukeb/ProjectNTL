using UnityEngine;

namespace NTL.Physics
{
    [RequireComponent(typeof(Rigidbody))]
    public class RigidbodyController : MonoBehaviour
    {
        [SerializeField] new private Rigidbody rigidbody;

        public Vector3 FacingDirection => transform.forward;

        //public float rotationSmoothing;

        // move towards where tank is facing
        public void MoveForward(float speed)
        {
            Vector3 newVel = FacingDirection * speed;
            newVel.y = rigidbody.velocity.y;
            rigidbody.velocity = newVel;
        }

        // rotate on z axis around self
        public void Rotate(float speed)
        {
            //Vector3 rot = transform.eulerAngles;
            //rot.y = Mathf.Lerp(rot.y, rot.y + speed, rotationSmoothing);
            //transform.localRotation = Quaternion.Euler(rot);
            transform.Rotate(0, speed, 0, Space.Self);
        }
    }
}
