﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public EnemyPool Pool { get; set; }
    [SerializeField] Enemy enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        GameObject castle = GameObject.Find("Base");
        if (castle)
        {
            GetComponent<NavMeshAgent>().destination = castle.transform.position;
        }
    }
    void OnTriggerEnter(Collider co)
    {
        // If castle then deal Damage
        if (co.name == "Base")
        {
            co.GetComponentInChildren<BaseHealth>().Decrease();
            Pool.ReturnToPool(enemyPrefab);
            enemyPrefab.Pool.ReturnToPool(enemyPrefab);
        }
    }
}
