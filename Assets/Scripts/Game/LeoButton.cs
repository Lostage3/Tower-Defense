using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeoButton : MonoBehaviour
{
    public GameObject TerrainPrefab;

    public GameObject LeoPrefab;

    AnimalPlace animalPlace;

    private void Start()
    {
        animalPlace = TerrainPrefab.GetComponent<AnimalPlace>();
    }

    private void OnMouseUpAsButton()
    {
        animalPlace.AnimalPrefab = LeoPrefab;
    }
}
