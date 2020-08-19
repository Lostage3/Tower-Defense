using UnityEngine;

public class Enemy : MonoBehaviour
{
   
    public EnemyPool Pool { get; set; } 
    
    public int health;

    AnimalAttack attack;

    private void Update()
    {
        if(health <= 0)
        {
            Pool.ReturnToPool(this);
            this.health = 100;
        }
    }

    public void DecreaseHealth(int amount)
    {
        if (health > 0)
        {
            health -= amount;
        }
        else
        {
            Pool.ReturnToPool(this);
            //health = 100;
        }
    }

    void OnTriggerEnter(Collider co)

    {
        if (co.name == "Base")
        {
            Pool.ReturnToPool(this);

        }
       
    }
}


