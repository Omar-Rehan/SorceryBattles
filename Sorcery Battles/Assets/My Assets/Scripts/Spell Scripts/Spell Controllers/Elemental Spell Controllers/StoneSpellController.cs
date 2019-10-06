using UnityEngine;

public class StoneSpellController : SpellController {
    public override void Start() {
        base.Start();
        RedirectSpell();
        RepositionSpell();
        Destroy(gameObject, 6.0f);
    }

    private void RedirectSpell() {
        transform.forward = new Vector3(m_direction.x, 0.0f, m_direction.z);
    }
    private void RepositionSpell() {
        transform.position = new Vector3(transform.position.x, 1.0f, transform.position.z);
    }
}
