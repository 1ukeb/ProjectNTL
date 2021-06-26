using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NTL.Physics;

namespace NTL.Gameplay
{
    public class TankController : MonoBehaviour
    {
        [SerializeField] private RigidbodyController controller;

        // key used to control this tank
        public string key;
        // is there currently input for this key
        public bool keyInput;

        [Space]
        [Header("Settings")]
        [SerializeField] private float speed;
        [SerializeField] private float rotateSpeed;

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
