using UnityEngine;
using NTL.Gameplay;
using TMPro;

namespace NTL.UI
{
    public class TankCanvas : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI tankText;

        private void Start() => tankText.text = GetComponentInParent<TankController>().key;
        void Update() => transform.forward = UnityEngine.Camera.main.transform.forward;
    }
}
