using UnityEngine;

public class AttackSpellController : ThrowableSpellController {
    void Update() {
        transform.LookAt(PlayerController.s_playerPosition);
        m_direction = transform.forward;
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "MainCamera") {
            GameManager.GetHit();
            Destroy(gameObject);
        }
        if (other.tag == "Spell") ElementalMagic.SpellCollision(other.gameObject, gameObject);
    }
}
