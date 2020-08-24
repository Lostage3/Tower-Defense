using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirButton : MonoBehaviour
{
    public GameObject TerrainPrefab;

    public GameObject GirPrefab;

    AnimalPlace animalPlace;

    private void Start()
    {
        animalPlace = TerrainPrefab.GetComponent<AnimalPlace>();
    }

    private void OnMouseUpAsButton()
    {
        animalPlace.AnimalPrefab = GirPrefab;
    }
}
