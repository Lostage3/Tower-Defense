using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject TerrainPrefab;

    public GameObject ElePrefab;

    AnimalPlace animalPlace;
    
    private void Start()
    {
        animalPlace = TerrainPrefab.GetComponent<AnimalPlace>();
    }

    private void OnMouseUpAsButton()
    {
        animalPlace.AnimalPrefab = ElePrefab;
    }
}
