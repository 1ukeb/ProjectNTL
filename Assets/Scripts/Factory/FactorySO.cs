using UnityEngine;

namespace NTL.Factory
{
    public abstract class FactorySO<T> : ScriptableObject, IFactory<T>
    {
        public abstract T Create();
    }
}
