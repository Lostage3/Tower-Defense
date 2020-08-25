using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalButton : MonoBehaviour
{
    //public GameObject TerrainPrefab;
    //public AnimalPlace AnimalPlacePrefab;
    public Transform BuildingPlaces;
    public AnimalType animalType;

    //AnimalPlace animalPlace;

    //private void Start()
    //{
    //    animalPlace = TerrainPrefab.GetComponent<AnimalPlace>();
    //}

    private void OnMouseUpAsButton()
    {
        foreach (Transform t in BuildingPlaces.transform)
        {
            var ap = t.GetComponent<AnimalPlace>();
            print(ap == null);
            t.GetComponent<AnimalPlace>().AnimalType = animalType;
            print(t.GetComponent<AnimalPlace>().AnimalType);
        }
    }
}

public enum AnimalType
{
    Ele, Gir, Leo
}