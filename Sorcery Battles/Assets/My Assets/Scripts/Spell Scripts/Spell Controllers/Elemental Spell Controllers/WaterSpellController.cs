using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpellController : ThrowableSpellController {
    private float rotationAngle = 4.0f;

    public override void FixedUpdate() {
        base.FixedUpdate();
        transform.Rotate(transform.up, rotationAngle);
    }

    public override void PrepareToDie() {
        base.PrepareToDie();
        rotationAngle = 0.0f;
    }
}
