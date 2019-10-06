using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour {
    public void LoadScene(string scene) {
        Debug.Log(scene);
        SceneManager.LoadScene(scene);
    }
}
