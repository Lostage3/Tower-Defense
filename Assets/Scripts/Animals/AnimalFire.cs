using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalFire : MonoBehaviour
{
    public List<GameObject> enemiesInRange;

    private float lastShotTime;
    private AnimalData animalData;

    private void Start()
    {
        enemiesInRange = new List<GameObject>();
        lastShotTime = Time.time;
        animalData = gameObject.GetComponentInChildren<AnimalData>();
    }

    private void Update()
    {
        GameObject target = null;
        
        float minimalEnemyDistance = float.MaxValue;
        foreach (GameObject enemy in enemiesInRange)
        {
            float distanceToGoal = enemy.GetComponent<MoveEnemy>().DistanceToGoal();
            if (distanceToGoal < minimalEnemyDistance)
            {
                target = enemy;
                minimalEnemyDistance = distanceToGoal;
            }
        }
        
        if (target != null)
        {
            if (Time.time - lastShotTime > animalData.CurrentLevel.fireRate)
            {
                Shoot(target.GetComponent<Collider>());
                lastShotTime = Time.time;
            }
            
            Vector3 direction = gameObject.transform.position - target.transform.position;
            gameObject.transform.rotation = Quaternion.AngleAxis(
                Mathf.Atan2(direction.y, direction.x) * -180 / Mathf.PI,
                new Vector3(0, 1, 0));
        }
    }

    void OnEnemyDestroy(GameObject enemy)
    {
        enemiesInRange.Remove(enemy);
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Add(other.gameObject);
            EnemyDestructionDelegate del =
                other.gameObject.GetComponent<EnemyDestructionDelegate>();
            del.enemyDelegate += OnEnemyDestroy;
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Remove(other.gameObject);
            EnemyDestructionDelegate del =
                other.gameObject.GetComponent<EnemyDestructionDelegate>();
            del.enemyDelegate -= OnEnemyDestroy;
        }
    }

    void Shoot(Collider target)
    {
        GameObject bulletPrefab = animalData.CurrentLevel.bullet;
        
        Vector3 startPosition = gameObject.transform.position;
        Vector3 targetPosition = target.transform.position;
        
        GameObject newBullet = Instantiate(bulletPrefab,transform.position,Quaternion.identity);
        newBullet.transform.position = startPosition;
        BulletBehavior bulletComp = newBullet.GetComponent<BulletBehavior>();
        bulletComp.target = target.gameObject;
        bulletComp.startPosition = startPosition;
        bulletComp.targetPosition = targetPosition;
    }
}
