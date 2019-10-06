using UnityEngine;
using HTC.UnityPlugin.Vive;

public class UseViveInput : MonoBehaviour {
    public HandRole m_handRole;
    private SpellSwitcherController m_spellSwitcherScript;

    void Start() {
        ElementalMagic.FillSpellsArray();
        m_spellSwitcherScript = (transform.GetChild(1)).GetComponent<SpellSwitcherController>();
    }
    void Update() {
        UpdateSpellSwitcher();
        if (ViveInput.GetPressDown(m_handRole, ControllerButton.Trigger)) {
            ElementalMagic.CastSpell(transform.position, transform.forward);
        }
        if (ViveInput.GetPressDown(m_handRole, ControllerButton.Grip)) {
            ElementalMagic.SwitchSpell();
        }
        if (ViveInput.GetPressDown(m_handRole, ControllerButton.PadTouch)) {
            m_spellSwitcherScript.Activate();

        } else if (ViveInput.GetPress(m_handRole, ControllerButton.PadTouch)) {
            Vector2 touchPosition = ViveInput.GetPadAxis(m_handRole, true);

            if (touchPosition.x > 0 && touchPosition.y > 0) { // First Quadrant
                ElementalMagic.ChangeSpell(ElementalMagic.MagicType.Fire);

            } else if (touchPosition.x < 0 && touchPosition.y > 0) { // Second Quadrant
                ElementalMagic.ChangeSpell(ElementalMagic.MagicType.Water);

            } else if (touchPosition.x < 0 && touchPosition.y < 0) { // Third Quadrant
                ElementalMagic.ChangeSpell(ElementalMagic.MagicType.Lightning);

            } else if (touchPosition.x > 0 && touchPosition.y < 0) { // Fourth Quadrant
                ElementalMagic.ChangeSpell(ElementalMagic.MagicType.Stone);

            }

        } else if (ViveInput.GetPressUp(m_handRole, ControllerButton.PadTouch)) {
            m_spellSwitcherScript.Deactivate();
        }
    }

    private void UpdateSpellSwitcher() {
        if (m_spellSwitcherScript.gameObject.activeSelf == true)
            m_spellSwitcherScript.HighlightSpell((int)ElementalMagic.s_currentMagicType);
    }
}