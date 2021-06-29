using UnityEngine;

// Destroy game object after particles completed
public class DestroyParticles : MonoBehaviour
{
    private void Start() =>
        Destroy(gameObject, GetComponent<ParticleSystem>().main.duration - 0.1f);
    // destroy after particle duration
    // - 0.1 seconds to stop first frame of particle playing bug
}
