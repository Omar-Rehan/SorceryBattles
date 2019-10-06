using UnityEngine;

public class SpellController : MonoBehaviour {
    public ElementalMagic.MagicType m_elementType;
    
    // For Movement/Collision
    protected Rigidbody m_rigidbody;

    protected Vector3 m_direction;
    protected Vector3 m_controllerPosition;

    public AudioClip m_awakeAudioClip;
    public AudioClip m_deathAudioClip;


    public virtual void Start() {
        m_rigidbody = GetComponent<Rigidbody>();
        m_direction = Vector3.Normalize(transform.position - m_controllerPosition);
        PlayAudioClip(m_awakeAudioClip);
    }

    public void SetControllerPosition(Vector3 controllerPosition) {
        m_controllerPosition = controllerPosition;
    }

    public virtual void PrepareToDie() {
        m_rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        PlayDeathAnimation();
        PlayAudioClip(m_deathAudioClip);
    }

    protected void PlayDeathAnimation() {
        Animator animator = gameObject.GetComponent<Animator>();
        if (animator != null) {
            animator.SetTrigger("Death");
            Destroy(gameObject, 0.5f);
        }

        ParticleSystem particleSystem = gameObject.GetComponent<ParticleSystem>();
        if (particleSystem != null) particleSystem.Play();

        StoneSelfDestruct selfDestructScript = gameObject.GetComponent<StoneSelfDestruct>();
        if (selfDestructScript != null) {
            selfDestructScript.SelfDestruct();
            Destroy(gameObject, 1.0f);
        }
    }
    protected void PlayAudioClip(AudioClip audioClip) {
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource != null && audioClip != null) {
            audioSource.PlayOneShot(audioClip);
        }
    }
}
