using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAim : MonoBehaviour
{
   
    public GameObject BulletPrefab;
   
    void OnTriggerEnter(Collider co)
    {
        if (co.CompareTag("Enemy"))
        {
            GameObject g = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            g.GetComponent<AnimalAttack>().Target = co.transform;
        }
    }
}
