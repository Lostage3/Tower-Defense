using UnityEngine;

public class Enemy : MonoBehaviour
{    
    public int Health;
    public int MaxHealth;

    private void Awake()
    {
        Health = MaxHealth;
    }

   // private void Update()
   // {
    //    if (Health <= 0)
   //     {
   //         Destroy(gameObject);

    //    }
    //}


    public void DecreaseHealth(int amount)
    {
        if (Health > 0)
        {
            Health -= amount;

        }
        
    } 
}


