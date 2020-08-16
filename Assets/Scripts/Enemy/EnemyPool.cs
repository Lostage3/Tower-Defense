using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] Enemy enemyPrefab;
    [SerializeField] int maxCapacity = 24;
    Stack<Enemy> enemies;

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
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= SpawnTime)
        {
            GetNext(transform.position);
            timer = 0;
        }
    }
    public Enemy GetNext(Vector3 pos)
    {
        Enemy enemy;

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
