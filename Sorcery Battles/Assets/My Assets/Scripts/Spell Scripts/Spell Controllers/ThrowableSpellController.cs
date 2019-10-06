using UnityEngine;

public class ThrowableSpellController : SpellController {
    public float m_movingSpeed;

    public override void Start() {
        base.Start();
        Destroy(gameObject, 20.0f);
    }

    public virtual void FixedUpdate() {
        if (m_rigidbody != null) m_rigidbody.AddForce(m_direction * m_movingSpeed);
        else Debug.Log(gameObject.name + "has no rigidbody");
    }
}
