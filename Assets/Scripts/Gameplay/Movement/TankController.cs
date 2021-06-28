using UnityEngine;
using NTL.Physics;
using NTL.Spawning;

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

        private void OnEnable() => TankSpawner.activeTanks.Add(this);
        private void OnDisable() => TankSpawner.activeTanks.Remove(this);

        public void AddSpeed(float speed) => this.speed += speed;
        public void RemoveSpeed(float speed) => this.speed -= speed;

        // check input of key
        private void Update() => keyInput = UnityEngine.Input.GetKey(key);

        private void FixedUpdate()
        {
            // if key input, rotate controller
            if (keyInput)
                controller.Rotate(rotateSpeed);

            // move forward
            controller.MoveForward(speed);
        }
    }
}
