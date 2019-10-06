using UnityEngine;

public class TrainingAttackController : MonoBehaviour {
    public ElementalMagic.MagicType m_elementType;

    public AudioClip m_awakeAudioClip;
    public AudioClip m_deathAudioClip;

    void Start() {
        PlayAudioClip(m_awakeAudioClip);
    }

    public void PrepareToDie() {
        ParticleSystem particleSystem = gameObject.GetComponent<ParticleSystem>();
        if (particleSystem != null) particleSystem.Play();

        PlayDeathAnimation();
        PlayAudioClip(m_deathAudioClip);
    }

    protected void PlayDeathAnimation() {
        Animator animator = gameObject.GetComponent<Animator>();
        if (animator != null) {
            animator.SetTrigger("Death");
            Destroy(gameObject, 0.5f);
            return;
        }

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

    void OnTriggerEnter(Collider other) {
        if (other.tag == "MainCamera") Destroy(gameObject);
        if (other.tag == "Spell") ElementalMagic.TrainingCollision(other.gameObject, gameObject);
    }
}
