using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private static bool s_bBeingHit;
    public static int s_playerHealth;

    public GameObject enemySpawner;
    public GameObject[] spellSwitchers;

    public Canvas scenesCanvas;
    public static Canvas damageCanvas;

    void Start() {
        s_bBeingHit = false;
        s_playerHealth = 3;
        damageCanvas = GameObject.Find("UI Elements").transform.GetChild(1).gameObject.GetComponent<Canvas>();
    }
    void Update() {
        if (s_bBeingHit) ShowDamageVisual();
        if (IsPlayerDead()) StopGame();
    }

    public static void GetHit() {
        s_playerHealth--;
        s_bBeingHit = true;
    }

    private void ShowDamageVisual() {
        if (damageCanvas != null) damageCanvas.gameObject.SetActive(true);
        s_bBeingHit = false;
        StartCoroutine("ComeBackToLife");
    }
    private IEnumerator ComeBackToLife() {
        yield return new WaitForSeconds(0.5f);
        damageCanvas.gameObject.SetActive(false);
    }

    private bool IsPlayerDead() {
        return s_playerHealth <= 0;
    }
    private void StopGame() {
        enemySpawner.SetActive(false);
        scenesCanvas.gameObject.SetActive(true);
        for (int i = 0; i < spellSwitchers.Length; i++) spellSwitchers[i].SetActive(false);
    }
}
