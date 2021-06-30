using UnityEngine;

// destroy gameObject after seconds
public class DestroySeconds : MonoBehaviour
{
    public void SetSeconds(float seconds) => this.seconds = seconds;
    [SerializeField] private float seconds;
    private void Start() => Destroy(gameObject, seconds);
}
