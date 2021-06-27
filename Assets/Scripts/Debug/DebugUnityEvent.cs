using UnityEngine;
using UnityEngine.Events;

namespace NTL.Debug
{
    public class DebugUnityEvent : MonoBehaviour
    {
        public UnityEvent unityEvent;
        public string debugKey;

        private void Update()
        {
            if(UnityEngine.Input.GetKeyDown(debugKey))
                unityEvent?.Invoke();
        }
    }
}
