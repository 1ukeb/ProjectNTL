using UnityEngine;

namespace NTL.Factory
{
    [CreateAssetMenu(menuName = "NTL/GameObject Factory")]
    public class GameObjectFactorySO : FactorySO<GameObject>
    {
        [SerializeField] private GameObject tankPrefab;

        public override GameObject Create()
        {
            return Instantiate(tankPrefab);
        }
    }
}
