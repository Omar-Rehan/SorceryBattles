using UnityEngine;

public class StoneRemainsScript : MonoBehaviour {
    public float explosionForce;

    void Start() {
        Vector3 rockCenter = transform.parent.position;
        gameObject.GetComponent<Rigidbody>().AddForce((transform.position - rockCenter) * explosionForce);
        Destroy(gameObject, 2.0f);
    }

    void Update() {
        transform.Rotate(transform.up, Random.Range(15.0f, 20.0f));
    }
}
