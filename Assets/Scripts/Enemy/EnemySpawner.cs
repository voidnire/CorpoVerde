using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave{
        public GameObject enemyPrefab;
        public float spawnInterval = 3f;
        public float spawnTimer;

        public int enemiesPerWave;
        public int spawnedEnemyCount;

    }

    public List<Wave> waves; 
    public int waveNumber;
    public Transform minPos;
    public Transform maxPos;

    void Update()
    {
        if (PlayerController.Instance.gameObject.activeSelf) // se tiver player
        {
            waves[waveNumber].spawnTimer += Time.deltaTime;
            if (waves[waveNumber].spawnTimer >= waves[waveNumber].spawnInterval)
            {
                waves[waveNumber].spawnTimer = 0f;
                SpawnEnemy();
            }

            if (waves[waveNumber].spawnedEnemyCount >= waves[waveNumber].enemiesPerWave)
            {
                waves[waveNumber].spawnedEnemyCount = 0;

                if (waves[waveNumber].spawnInterval > 0.5f)
                    waves[waveNumber].spawnInterval *= 0.9f;

                waveNumber++;
            }

            if (waveNumber >= waves.Count)
            {
                //enabled = false; // Stop spawning when all waves are completed
                waveNumber = 0; // pra recomeçar
            }
        }
    }
    void SpawnEnemy(){
        Instantiate(waves[waveNumber].enemyPrefab, RandomSpawnPoint(), Quaternion.identity); // ou transform.rotation
        waves[waveNumber].spawnedEnemyCount++;
    }

    private Vector2 RandomSpawnPoint(){
        Vector2 spawnPoint;

        if (Random.Range(0f, 1f) > 0.5)
        {
            spawnPoint.x = Random.Range(minPos.position.x, maxPos.position.x);
            if (Random.Range(0f, 1f) > 0.5)
                spawnPoint.y = minPos.position.y; ///top
            else
                spawnPoint.y = maxPos.position.y;///bottom

        }
        else
        {
            spawnPoint.y = Random.Range(minPos.position.y, maxPos.position.y);
            if (Random.Range(0f, 1f) > 0.5)
                spawnPoint.x = minPos.position.x; ///left
            else
                spawnPoint.x = maxPos.position.x; ///left
        }


        return spawnPoint;
    }
}
