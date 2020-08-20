using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float speed = 10;
    public int damage;
    public GameObject target;
    public Vector3 startPosition;
    public Vector3 targetPosition;
    public Enemy enemy;

    private float distance;
    private float startTime;

    private GameManagerBehaviour gameManager;

    private void Start()
    {
        startTime = Time.time;
        distance = Vector3.Distance(startPosition, targetPosition);
        GameObject gm = GameObject.Find("GameManager");
        gameManager = gm.GetComponent<GameManagerBehaviour>();
    }
    private void Update()
    {
        float timeInterval = Time.time - startTime;
        gameObject.transform.position = Vector3.Lerp(startPosition, targetPosition, timeInterval * speed / distance);

        
        if (gameObject.transform.position.Equals(targetPosition))
        {
            if (target != null)
            {
                

                if (enemy.Health > 0)
                {
                    enemy.DecreaseHealth(damage);
                }
                else
                { 
                    Destroy(target);
                    gameManager.Food += 10;
                }
            }
            Destroy(gameObject);
        }
    }
}
