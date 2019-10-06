using UnityEngine;

public static class ElementalMagic {
    public enum MagicType { Fire, Water, Lightning, Stone };
    public static short s_numOfMagicElements = 4;

    public static MagicType s_currentMagicType = MagicType.Fire;
    public static GameObject[] s_spellObjects = new GameObject[s_numOfMagicElements];


    public static void FillSpellsArray() {
        for (int index = 0; index < SpellHolder.singleton.spells.Length; index++) {
            s_spellObjects[index] = SpellHolder.singleton.spells[index];
        }
    }

    public static void ChangeSpell(MagicType newMagicType) {
        s_currentMagicType = newMagicType;
    }
    public static void SwitchSpell() {
        s_currentMagicType = (MagicType)(((int)s_currentMagicType + 1) % s_spellObjects.Length);
    }
    public static void CastSpell(Vector3 controllerPosition, Vector3 controllerForward) {
        GameObject spellObject = s_spellObjects[(int)s_currentMagicType];
        Vector3 spellSpawnPosition = controllerPosition + controllerForward;

        if (s_currentMagicType == MagicType.Stone) {
            RaycastHit hitInfo;
            if (!CheckStoneConditions(controllerPosition, controllerForward, out hitInfo)) return;
            else {
                spellSpawnPosition = hitInfo.point;
                spellSpawnPosition.y += 1.0f;
            }
        }

        GameObject castSpell = Object.Instantiate(spellObject, spellSpawnPosition, Quaternion.identity);
        SetSpellControllerPosition(castSpell, controllerPosition);
    }

    private static bool CheckStoneConditions(Vector3 controllerPosition, Vector3 controllerForward, out RaycastHit hitInfo) {
        LayerMask groundLayerMask = ~LayerMask.NameToLayer("Ground");
        return Physics.Raycast(controllerPosition, controllerForward, out hitInfo, Mathf.Infinity, groundLayerMask);
    }
    private static void SetSpellControllerPosition(GameObject castSpell, Vector3 controllerPosition) {
        SpellController spellControllerScript = castSpell.GetComponent<SpellController>();

        if (spellControllerScript != null) {
            spellControllerScript.SetControllerPosition(controllerPosition);
        } else {
            Debug.Log("No SpellController Script!!");
        }
    }

    public static void SpellCollision(GameObject spell, GameObject attack) {
        SpellController spellControllerScript = spell.GetComponent<SpellController>();
        SpellController attackControllerScript = attack.GetComponent<SpellController>();

        MagicType spellType = spellControllerScript.m_elementType;
        MagicType attackType = attackControllerScript.m_elementType;

        spellControllerScript.PrepareToDie();
        if ((int)spellType == (int)(attackType + 1) % s_numOfMagicElements) {
            attackControllerScript.PrepareToDie();
        }
    }
    public static void TrainingCollision(GameObject spell, GameObject trainingAttack) {
        SpellController spellControllerScript = spell.GetComponent<SpellController>();
        TrainingAttackController trainingAttackControllerScript = trainingAttack.GetComponent<TrainingAttackController>();

        MagicType spellType = spellControllerScript.m_elementType;
        MagicType attackType = trainingAttackControllerScript.m_elementType;

        spellControllerScript.PrepareToDie();
        if ((int)spellType == (int)(attackType + 1) % s_numOfMagicElements) {
            trainingAttackControllerScript.PrepareToDie();
        }
    }

}
