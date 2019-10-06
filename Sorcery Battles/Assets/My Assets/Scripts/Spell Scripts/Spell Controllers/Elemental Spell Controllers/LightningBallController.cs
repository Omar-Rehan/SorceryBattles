using UnityEngine;

public class LightningBallController : AttackSpellController {
    public override void FixedUpdate() {
        base.FixedUpdate();
        transform.Rotate(transform.up, 2.0f);
    }
}
