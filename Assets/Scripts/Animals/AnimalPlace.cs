using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalPlace : MonoBehaviour
{
    public GameObject AnimalPrefab;

    private void OnMouseUpAsButton()
    {
        GameObject animal = Instantiate(AnimalPrefab,new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z),Quaternion.identity);
        //animal.transform.position += new Vector3(transform.position.x,transform.position.y + 5f,transform.position.z);
    }
}
