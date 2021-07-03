using UnityEngine;

namespace NTL.App
{
    public class AppManager : MonoBehaviour
    {
        public static AppManager Singleton;
        private void Awake()
        {
            Singleton = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
