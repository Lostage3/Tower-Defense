using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour
{
    public TextMesh baseHealth;
    public Text Death;
    
    void Start()
    {
        baseHealth = GetComponent<TextMesh>();
    }

    
    void Update()
    {
        transform.forward = Camera.main.transform.forward;
    }

    public int current()
    {
        return baseHealth.text.Length;
    }

    public void Decrease()
    {
        if (current() > 1)
        {
            baseHealth.text = baseHealth.text.Remove(baseHealth.text.Length - 1);
        }
        else
        {
            Destroy(transform.parent.gameObject);
            Death.text = "You Lose";
            
        }
    }
}
