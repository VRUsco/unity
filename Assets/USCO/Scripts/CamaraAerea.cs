using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraAerea : MonoBehaviour
{
    [SerializeField] private GameObject camaraAerea;
    [SerializeField] private GameObject personaje;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            camaraAerea.SetActive(false);
            personaje.SetActive(true);
        }
    }
}
