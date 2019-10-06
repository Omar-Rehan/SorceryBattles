using UnityEngine;

public class PlayerController : MonoBehaviour {
    public static Vector3 s_playerPosition;
    void Update() {s_playerPosition = transform.position;}
}
