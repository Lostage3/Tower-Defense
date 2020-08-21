using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject TerrainPrefab;

    AnimalPlace animalPlace;

    private void Start()
    {
        animalPlace = TerrainPrefab.GetComponent<AnimalPlace>();
    }

  


}
