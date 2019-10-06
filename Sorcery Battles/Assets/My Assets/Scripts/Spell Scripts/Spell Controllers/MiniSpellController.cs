using UnityEngine;

public class MiniSpellController : MonoBehaviour {
    /// Show/Hide the spell switcher wholly
    public void Activate() {
        gameObject.SetActive(true);
    }
    public void Deactivate() {
        gameObject.SetActive(false);
    }

}
