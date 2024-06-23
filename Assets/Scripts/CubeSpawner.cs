using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject m_cubePrefab;
    [SerializeField] private Transform m_spawnerTF;
    [SerializeField] private Transform m_playerTF;
    [SerializeField] private Vector2 m_randomizedSpawnHeight;
    [SerializeField] private Vector2 m_spawnFrequency;
    [SerializeField] private Vector2 m_spawnAreaX;
    [SerializeField] private Vector2 m_spawnAreaZ;

    private float m_spawnTimer;

    private void Update()
    {
        if (GameController.Instance.gameStarted == false) return;

        CountSpawnTimer();
        UpdateSpawnerPosition();
    }

    private void UpdateSpawnerPosition()
    {
        float spawnHeight = Random.Range(m_randomizedSpawnHeight.x, m_randomizedSpawnHeight.y);
        m_spawnerTF.position = new Vector3(m_playerTF.position.x, m_playerTF.position.y - spawnHeight, m_playerTF.position.z);
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
        Vector3 spawnPosition = new Vector3(m_spawnerTF.position.x + spawnPositionX, m_spawnerTF.position.y, m_spawnerTF.position.z + spawnPositionZ);
        Instantiate(m_cubePrefab, spawnPosition, Quaternion.identity);
    }
}