using UnityEngine;

namespace NTL.App
{
    public class App : MonoBehaviour
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Load()
        {
            // If already found app gameobject
            if(FindObjectOfType<AppManager>())
                return;

            GameObject app = Resources.Load("App") as GameObject;
            GameObject go = Instantiate(app);
            go.name = "App";
        }
    }
}
