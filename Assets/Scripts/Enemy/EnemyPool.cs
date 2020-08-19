using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] Enemy enemyPrefab;
    [SerializeField] int maxCapacity = 24;
    Stack<Enemy> enemies;

    public Wave[] waves;
    public int timeBetweenWaves = 5;

    private GameManagerBehaviour gameManager;

    private float lastSpawnTime;
    private int enemiesSpawned = 0;

    Enemy enemy;

    float timer;
    public float SpawnTime = 1f;
    private void Awake()
    {
        enemies = new Stack<Enemy>(maxCapacity);

        for (int i = 0; i < maxCapacity; i++)
        {
            Enemy enemy = Instantiate(enemyPrefab, transform);
            enemy.Pool = this;
            enemy.gameObject.SetActive(false);
            enemies.Push(enemy);
        }
    }
    private void Start()
    {
        lastSpawnTime = Time.time;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehaviour>();
    }
    private void Update()
    {
        int currentWave = gameManager.Wave;
        if (currentWave < waves.Length)
        {
            // 2
            float timeInterval = Time.time - lastSpawnTime;
            float spawnInterval = waves[currentWave].spawnInterval;
            if (((enemiesSpawned == 0 && timeInterval > timeBetweenWaves) || timeInterval > spawnInterval) &&
                enemiesSpawned < waves[currentWave].maxEnemies)
            {
                // 3  
                lastSpawnTime = Time.time;
                GameObject newEnemy =Instantiate(waves[currentWave].enemyPrefab);
                GetNext(transform.position);
                enemiesSpawned++;
            }
            // 4 
            if (enemiesSpawned == waves[currentWave].maxEnemies &&
                GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                gameManager.Wave++;
                gameManager.Food = Mathf.RoundToInt(gameManager.Food * 1.1f);
                enemiesSpawned = 0;
                lastSpawnTime = Time.time;
            }
            // 5 
        }
       
    }
    public Enemy GetNext(Vector3 pos)
    {
        

        if (enemies.Count > 0)
        {
            enemy = enemies.Pop();
        }
        else
        {
            enemy = Instantiate(enemyPrefab, transform);
            enemy.Pool = this;
        }
        enemy.transform.position = pos;
        enemy.transform.rotation = enemyPrefab.transform.rotation;
        enemy.gameObject.SetActive(true);
        enemy.transform.parent = null;
        return enemy;

    }

    public void ReturnToPool(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
        enemy.transform.position = Vector3.zero;
        enemy.transform.rotation = enemyPrefab.transform.rotation;
        enemy.transform.parent = transform;
        enemy.GetComponent<Rigidbody>().velocity = Vector3.zero;
        enemy.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        enemies.Push(enemy);
    }
}


