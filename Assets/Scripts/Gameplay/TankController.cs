using UnityEngine;
using NTL.Physics;

namespace NTL.Gameplay
{
    public class TankController : MonoBehaviour
    {
        [Space]
        [Header("Components")]
        // rb physics controller
        [SerializeField] private RigidbodyController controller;

        [Space]
        [Header("Input")]
        // key used to control this tank
        public string key;
        // is there currently input for this key
        public bool keyInput;

        [Space]
        [Header("Settings")]
        // move speed of tank
        [SerializeField] private float speed;
        // rotate speed of tank
        [SerializeField] private float rotateSpeed;

        // check input of key
        private void Update() => keyInput = Input.GetKey(key);

        private void FixedUpdate()
        {
            controller.MoveForward(speed);

            // if key input, rotate controller
            if (keyInput)
                controller.Rotate(rotateSpeed);
        }
    }
}
