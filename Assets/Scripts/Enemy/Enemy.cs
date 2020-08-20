using UnityEngine;

public class Enemy : MonoBehaviour
{    
    public int Health;
    public int MaxHealth;

    private void Start()
    {
        Health = MaxHealth;
    } 

   

    public void DecreaseHealth(int amount)
    {
        if (Health > 0)
        {
            Health -= amount;
        }
        
    } 
}


