using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject m_cubePrefab;
    [SerializeField] private Transform m_spawnerTF;
    [SerializeField] private Vector2 m_spawnFrequency;
    [SerializeField] private Vector2 m_spawnAreaX;
    [SerializeField] private Vector2 m_spawnAreaZ;

    private float m_spawnTimer;

    private void Update()
    {
        CountSpawnTimer();
    }

    private void CountSpawnTimer()
    {
        float spawnRate = Random.Range(m_spawnFrequency.x, m_spawnFrequency.y);
        m_spawnTimer += Time.deltaTime;
        if (m_spawnTimer >= spawnRate)
        {
            m_spawnTimer = 0;
            SpawnCube();
        }
    }

    private void SpawnCube()
    {
        float spawnPositionX = Random.Range(m_spawnAreaX.x, m_spawnAreaX.y);
        float spawnPositionZ = Random.Range(m_spawnAreaZ.x, m_spawnAreaZ.y);
        Vector3 spawnPosition = new Vector3(spawnPositionX, m_spawnerTF.position.y, spawnPositionZ);
        Instantiate(m_cubePrefab, spawnPosition, Quaternion.identity);
    }
}