using UnityEngine;

public class Spawners : MonoBehaviour
{
    public float SpawningRate = 2f;
    public GameObject EnemyPrefab;
    public Transform[] SpawnPoints;
    public Player Player;

    private float LastSpawnTime; 
    
    void Update()
    {
        if (Player == null) return;
        
        if (LastSpawnTime + SpawningRate < Time.time)
        {
            var randomSpawnPoint = SpawnPoints[Random.Range(0, SpawnPoints.Length - 1)];
            Instantiate(EnemyPrefab, randomSpawnPoint.position, Quaternion.identity);
            LastSpawnTime = Time.time;
            SpawningRate *= 0.98f;
        }
    }
}
