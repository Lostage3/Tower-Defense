using UnityEngine;

public class AnimalPlace : MonoBehaviour
{
    [SerializeField] AnimalType animalType;
    public AnimalType AnimalType
    {
        get { return animalType; }
        set
        {
            animalType = value;
            Debug.Log(animalType);
        }
    }
    public GameObject ElePrefab;
    public GameObject GirPrefab;
    public GameObject LeoPrefab;

    GameObject curAnimal;

    private GameManagerBehaviour gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehaviour>();
    }

    private bool CanPlaceAnimal(AnimalType animalType)
    {
        int cost = 0;
        switch (animalType)
        {
            case AnimalType.Ele:
                cost = ElePrefab.GetComponent<AnimalData>().levels[0].cost;
                return curAnimal == null && gameManager.Food >= cost;
            case AnimalType.Gir:
                cost = GirPrefab.GetComponent<AnimalData>().levels[0].cost;
                return curAnimal == null && gameManager.Food >= cost;
            case AnimalType.Leo:
                cost = LeoPrefab.GetComponent<AnimalData>().levels[0].cost;
                return curAnimal == null && gameManager.Food >= cost;
            default:
                return false;
        }
    }

    private bool CanUpgradeAnimal(AnimalType animalType)
    {
        switch (animalType)
        {
            case AnimalType.Ele:
                if (curAnimal != null)
                {
                    AnimalData eleData = curAnimal.GetComponent<AnimalData>();
                    AnimalLevel nextLevel = eleData.GetNextLevel();
                    if (nextLevel != null)
                    {
                        return gameManager.Food >= nextLevel.cost;
                    }
                }
                break;
            case AnimalType.Gir:
                if (curAnimal != null)
                {
                    AnimalData girData = curAnimal.GetComponent<AnimalData>();
                    AnimalLevel nextLevel = girData.GetNextLevel();
                    if (nextLevel != null)
                    {
                        return gameManager.Food >= nextLevel.cost;
                    }
                }
                break;
            case AnimalType.Leo:
                if (curAnimal != null)
                {
                    AnimalData leoData = curAnimal.GetComponent<AnimalData>();
                    AnimalLevel nextLevel = leoData.GetNextLevel();
                    if (nextLevel != null)
                    {
                        return gameManager.Food >= nextLevel.cost;
                    }
                }
                break;
            default:
                return false;
        }
        return false;
    }

    private void OnMouseUpAsButton()
    {
        print($"Animal Type is {AnimalType}");
        GameObject prefab = null;
        switch (AnimalType)
        {
            case AnimalType.Ele:
                prefab = ElePrefab;
                break;
            case AnimalType.Gir:
                prefab = GirPrefab;
                break;
            case AnimalType.Leo:
                prefab = LeoPrefab;
                break;
            default:
                break;
        }

        if (CanPlaceAnimal(AnimalType))
        {
            curAnimal = Instantiate(prefab, new Vector3(transform.position.x, transform.position.y + 4f, transform.position.z), Quaternion.identity);
            gameManager.Food -= curAnimal.GetComponent<AnimalData>().CurrentLevel.cost;
        }
        else if (CanUpgradeAnimal(AnimalType))
        {
            curAnimal.GetComponent<AnimalData>().IncreaseLevel();
            gameManager.Food -= curAnimal.GetComponent<AnimalData>().CurrentLevel.cost;
        }
    }

}
