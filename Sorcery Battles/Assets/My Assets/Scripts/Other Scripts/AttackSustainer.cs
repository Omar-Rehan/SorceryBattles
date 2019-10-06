using UnityEngine;

public class AttackSustainer : MonoBehaviour {
    private float m_timeSinceLastCheck;
    public Vector3[] m_spellPositions = new Vector3[ElementalMagic.s_numOfMagicElements];
    private GameObject[] m_trainingSpells = new GameObject[ElementalMagic.s_numOfMagicElements];
    public GameObject[] m_trainingSpellPrefabs = new GameObject[ElementalMagic.s_numOfMagicElements];

    void Start() {
        m_timeSinceLastCheck = 0.0f;
        for (int spellIndex = 0; spellIndex < ElementalMagic.s_numOfMagicElements; spellIndex++) {
            m_trainingSpells[spellIndex] = Instantiate(m_trainingSpellPrefabs[spellIndex], m_spellPositions[spellIndex], Quaternion.identity);
        }
    }

    void Update() {
        m_timeSinceLastCheck += Time.deltaTime;
        if (m_timeSinceLastCheck > 4.0f) {
            for (int spellIndex = 0; spellIndex < ElementalMagic.s_numOfMagicElements; spellIndex++) {
                if (m_trainingSpells[spellIndex] == null)
                    m_trainingSpells[spellIndex] = Instantiate(m_trainingSpellPrefabs[spellIndex], m_spellPositions[spellIndex], Quaternion.identity, transform);
            }
            m_timeSinceLastCheck = 0.0f;
        }
    }
}
