using UnityEngine;

public class SpellHolder : MonoBehaviour {
    public static SpellHolder singleton;
    void Awake() {
        singleton = this;
    }

    public GameObject[] spells;
}