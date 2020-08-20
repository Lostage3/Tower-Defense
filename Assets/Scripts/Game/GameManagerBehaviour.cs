using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManagerBehaviour : MonoBehaviour
{
    public GameObject Base;
    public Text FoodLabel;
    private int food;
    public int Food
    {
        get
        {
            return food;
        }
        set
        {
            food = value;
            FoodLabel.GetComponent<Text>().text = "Futter: " + food;
        }
    }
    public Text waveLabel;
    public bool gameOver = false;
    private int wave;
    public int Wave
    {
        get
        {
            return wave;
        }
        set
        {
            wave = value;
            
            waveLabel.text = "Welle: " + (wave + 1);
        }
    }
    public Text healthLabel;
    public GameObject[] healthIndicator;
    public Text WinText;
    private int health;
    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
            healthLabel.text = "Leben: " + health;
            
            if (health <= 0 && !gameOver)
            {
                gameOver = true;
                Base.SetActive(false);
                WinText.text = ("Verloren");
            }
            
            for (int i = 0; i < healthIndicator.Length; i++)
            {
                if (i < Health)
                {
                    healthIndicator[i].SetActive(true);
                }
                else
                {
                    healthIndicator[i].SetActive(false);
                }
            }
        }
    }
    private void Start()
    {
        Food = 100;
        Wave = 0;
        Health = 5;
    }
}
