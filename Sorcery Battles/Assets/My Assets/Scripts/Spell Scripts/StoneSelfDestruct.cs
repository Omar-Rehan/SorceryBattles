using UnityEngine;

public class StoneSelfDestruct : MonoBehaviour {
    public GameObject stoneRemainsPrefab;

    public void SelfDestruct() {
        if (stoneRemainsPrefab != null)
            Instantiate(stoneRemainsPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
