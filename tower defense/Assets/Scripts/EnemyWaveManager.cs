using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 1f;  // Interval between each enemy spawn
    public int maxEnemyCount;
    public List<Vector2Int> pathCells;

    private List<GameObject> activeEnemies = new List<GameObject>();
    private Dictionary<GameObject, int> enemyPathIndices = new Dictionary<GameObject, int>();
    private float spawnTimer;
    private GridManager gridManager;

    void Start()
    {
        spawnTimer = spawnInterval;  // Initialize the spawn timer to start spawning immediately
        gridManager = FindObjectOfType<GridManager>();
        pathCells = gridManager.pathCells;
        maxEnemyCount = gridManager.enemyCount;

    }

    void Update()
    {
        // Handle enemy spawning
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval && activeEnemies.Count < maxEnemyCount)
        {
            SpawnEnemy();
            spawnTimer = 0f;  // Reset spawn timer
        }

        // Move all active enemies along the path
        for (int i = activeEnemies.Count - 1; i >= 0; i--)
        {
            GameObject enemy = activeEnemies[i];
            if (enemy == null) 
            {
                activeEnemies.RemoveAt(i);
                continue;
            }

            int nextPathCellIndex = enemyPathIndices[enemy];
            if (nextPathCellIndex < pathCells.Count)
            {
                enemy.transform.position = Vector3.MoveTowards(
                    enemy.transform.position, 
                    new Vector3(pathCells[nextPathCellIndex].x, 0f, pathCells[nextPathCellIndex].y), 
                    Time.deltaTime * 3
                );
                if (enemy.transform.position == new Vector3(pathCells[nextPathCellIndex].x, 0f, pathCells[nextPathCellIndex].y))
                {
                    enemyPathIndices[enemy]++;
                }
            }
        }
    }

    public void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, new Vector3(pathCells[0].x, 0f, pathCells[0].y), Quaternion.identity);
        activeEnemies.Add(enemy);
        enemyPathIndices.Add(enemy, 1);
    }

    public void setPathCells(List<Vector2Int> newPathCells)
    {
        pathCells = newPathCells;
    }

    public void setEnemyCount(int newEnemyCount)
    {
        maxEnemyCount = newEnemyCount;
    }
}
