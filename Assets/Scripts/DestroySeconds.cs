using UnityEngine;

// destroy gameObject after seconds
public class DestroySeconds : MonoBehaviour
{
    [SerializeField] private float seconds;
    private void Start() => Destroy(gameObject, seconds);
}
