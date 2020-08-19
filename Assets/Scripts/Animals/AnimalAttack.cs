using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAttack : MonoBehaviour
{
    [SerializeField] float speed = 10;
    public float AttackSpeed;
    public int AttackDamage;
    public float AttackRange;

    public Transform Target;
    private void FixedUpdate()
    {
        if (Target)
        {
            // Fly towards the target
            Vector3 dir = Target.position - transform.position;
            GetComponent<Rigidbody>().velocity = dir.normalized * speed;
        }
        else
        {
            // Otherwise destroy self
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider co)
    {
        if(co == Target)
        {
            Destroy(gameObject);
        }
        Enemy enemy = co.GetComponent<Enemy>();
        if (co.CompareTag("Enemy"))
        {
            enemy.DecreaseHealth(AttackDamage);
            Destroy(gameObject);
        }
    }
}
