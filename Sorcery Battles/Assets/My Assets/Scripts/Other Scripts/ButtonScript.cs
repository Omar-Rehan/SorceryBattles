using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour {
    public string sceneName;

    void OnTriggerEnter(Collider other) {
        SceneManager.LoadScene(sceneName);
    }
}
