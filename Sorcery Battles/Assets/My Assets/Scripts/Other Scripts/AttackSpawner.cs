using UnityEngine;

public class AttackSpawner : MonoBehaviour {
    public GameObject[] m_attacks;

    public float m_distance, m_spawningCooldownTime;
    private float m_previousFrameTime, m_timeSinceLastSpawn;

    void Start() {
        m_timeSinceLastSpawn = 100.0f;
    }
    void Update() {
        if (IsSpawnTime()) {
            SpawnEnemy();
            m_timeSinceLastSpawn = 0.0f;
            m_spawningCooldownTime -= 0.1f;
        }
    }

    private bool IsSpawnTime() {
        m_timeSinceLastSpawn += Time.deltaTime;
        return (m_timeSinceLastSpawn > m_spawningCooldownTime);
    }
    private void SpawnEnemy() {
        GameObject attack = m_attacks[Random.Range(0, m_attacks.Length)];

        Vector3 attackInitialPosition;
        {
            float y = PlayerController.s_playerPosition.y; /// constant height
            float x = Random.Range(-m_distance, m_distance);
            float z = Mathf.Sqrt(m_distance * m_distance - x * x) * (2 * Random.Range(0, 2) - 1);
            attackInitialPosition = new Vector3(x, y, z);
        }

        Instantiate(attack, attackInitialPosition, Quaternion.identity, transform);
    }
}
