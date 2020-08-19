using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalPlace : MonoBehaviour
{
    public GameObject AnimalPrefab;
    GameObject animal;
   

    private GameManagerBehaviour gameManager;

    private void Start()
    {
        
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehaviour>();
    }

    private bool CanPlaceAnimal()
    {
        int cost = AnimalPrefab.GetComponent<AnimalData>().levels[0].cost;
        return animal == null && gameManager.Food >= cost;
    }

    private void OnMouseUpAsButton()
    {
        if (CanPlaceAnimal())
        {
            animal = Instantiate(AnimalPrefab, new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z), Quaternion.identity);
            gameManager.Food -= animal.GetComponent<AnimalData>().CurrentLevel.cost;
        }
        else if (CanUpgradeAnimal())
        {
            animal.GetComponent<AnimalData>().IncreaseLevel();
            gameManager.Food -= animal.GetComponent<AnimalData>().CurrentLevel.cost;
        }
    }
    private bool CanUpgradeAnimal()
    {
        if (animal != null)
        {
            AnimalData monsterData = animal.GetComponent<AnimalData>();
            AnimalLevel nextLevel = monsterData.GetNextLevel();
            if (nextLevel != null)
            {
                return gameManager.Food >= nextLevel.cost;
            }
        }
        return false;
    }
}
