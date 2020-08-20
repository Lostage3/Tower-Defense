using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElePlace : MonoBehaviour
{
    public GameObject AnimalPrefab;
    public GameObject animal;

    public GameObject Ele;
    public GameObject Gir;
    public GameObject Leo;

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

    public void OnMouseUpAsButton()
    {
        if (CanPlaceAnimal())
        {
            animal = Instantiate(AnimalPrefab, new Vector3(transform.position.x, transform.position.y + 4f, transform.position.z), Quaternion.identity);
            gameManager.Food -= animal.GetComponent<AnimalData>().CurrentLevel.cost;
            Ele.SetActive(false);
            Gir.SetActive(false);
            Leo.SetActive(false);
            
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
