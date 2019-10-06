using UnityEngine;
using UnityEngine.SceneManagement;
using DigitalRuby.LightningBolt;

public class LightningSpellController : SpellController {
    public float widthDecrease;
    private LightningBoltScript lightningBoltScript;

    public override void Start() {
        base.Start();

        lightningBoltScript = gameObject.GetComponent<LightningBoltScript>();
        InitializeLightningBolt();
        PositionLightningBolt();
        Destroy(gameObject, 2.0f);
    }

    void Update() {
        LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
        if (lineRenderer != null) {
            lineRenderer.startWidth = Mathf.Max(0.0f, lineRenderer.startWidth - widthDecrease);
            lineRenderer.endWidth = Mathf.Max(0.0f, lineRenderer.endWidth - widthDecrease);
        }
        lightningBoltScript.StartPosition = m_controllerPosition;
    }

    private void InitializeLightningBolt() {
        lightningBoltScript.StartObject = null;
        lightningBoltScript.EndObject = null;
        lightningBoltScript.Duration = 0.03f;
        lightningBoltScript.ChaosFactor = 0.1f;
        lightningBoltScript.AnimationMode = LightningBoltAnimationMode.None;
    }
    private void PositionLightningBolt() {
        /// Starting Position
        lightningBoltScript.StartPosition = m_controllerPosition;

        /// Ending Position
        {
            RaycastHit hitInfo;
            LayerMask layerMask = ~LayerMask.NameToLayer("Lit");
            if (Physics.Raycast(m_controllerPosition, m_direction, out hitInfo, Mathf.Infinity, layerMask)) {
                lightningBoltScript.EndPosition = hitInfo.transform.position;
                if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game Scene"))
                    ElementalMagic.SpellCollision(gameObject, hitInfo.transform.gameObject);
                else
                    ElementalMagic.TrainingCollision(gameObject, hitInfo.transform.gameObject);

            } else {
                lightningBoltScript.EndPosition = m_controllerPosition + 10.0f * m_direction;
            }
        }
    }
}
