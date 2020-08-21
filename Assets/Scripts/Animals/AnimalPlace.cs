using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalPlace : MonoBehaviour
{
    public GameObject ElePrefab;
    public GameObject GirPrefab;
    public GameObject LeoPrefab;
    GameObject ele;
    GameObject gir;
    GameObject leo;

    public GameObject EleButton;
    public GameObject GirButton;
    public GameObject Leobutton;

    private GameManagerBehaviour gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehaviour>();
    }

    private bool CanPlaceEle()
    {
        int cost = ElePrefab.GetComponent<AnimalData>().levels[0].cost;

        return ele == null && gameManager.Food >= cost;

    }

    private bool CanUpgradeEle()
    {
        if (ele != null)
        {
            AnimalData monsterData = ele.GetComponent<AnimalData>();
            AnimalLevel nextLevel = monsterData.GetNextLevel();
            if (nextLevel != null)
            {
                return gameManager.Food >= nextLevel.cost;
            }
        }
        return false;
    }

    private void OnMouseUpAsButton()
    {
        if (CanPlaceEle())
        {
            ele = Instantiate(ElePrefab, new Vector3(transform.position.x, transform.position.y + 4f, transform.position.z), Quaternion.identity);

            gameManager.Food -= ele.GetComponent<AnimalData>().CurrentLevel.cost;
        }
        else if (CanUpgradeEle())
        {
            ele.GetComponent<AnimalData>().IncreaseLevel();
            gameManager.Food -= ele.GetComponent<AnimalData>().CurrentLevel.cost;
        }
    }

}
