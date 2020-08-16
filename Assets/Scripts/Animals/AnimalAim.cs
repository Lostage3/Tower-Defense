using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAim : MonoBehaviour
{
    //[SerializeField] float attackDamage;
    //[SerializeField] float attackSpeed;
    //[SerializeField] float attackRange;
    public GameObject BulletPrefab;
   
    void OnTriggerEnter(Collider co)
    {
        // Was it a Monster? Then Shoot it
        if (co.CompareTag("Enemy"))
        {
            GameObject g = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            g.GetComponent<AnimalAttack>().Target = co.transform;
        }
    }
}
