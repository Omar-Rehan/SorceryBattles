using UnityEngine;

public class SpellSwitcherController : MonoBehaviour {
    private Renderer m_renderer;
    public Texture[] m_textures;

    private const int numOfMiniSpells = 4;
    private MiniSpellController[] m_miniSpellScripts = new MiniSpellController[numOfMiniSpells];
    
    void Start() {
        m_renderer = gameObject.GetComponent<Renderer>();
        if (m_renderer == null) Debug.Log("No renderer! " + gameObject.name);
        FillMiniSpellsArray();
    }

    private void FillMiniSpellsArray() {
        for (int index = 0; index < numOfMiniSpells; index++)
            m_miniSpellScripts[index] = (transform.GetChild(index)).GetComponent<MiniSpellController>();
    }
    public void HighlightSpell(int spellIndex) {
        m_renderer.material.mainTexture = m_textures[spellIndex];
    }

    public void Activate() {
        gameObject.SetActive(true);
        for (int index = 0; index < numOfMiniSpells; index++) {
            if (m_miniSpellScripts[index] != null) m_miniSpellScripts[index].Activate();
        }
    }
    public void Deactivate() {
        gameObject.SetActive(false);
        for (int index = 0; index < numOfMiniSpells; index++)
            if (m_miniSpellScripts[index] != null) m_miniSpellScripts[index].Deactivate();
    }
}
