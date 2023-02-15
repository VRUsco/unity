using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraAerea : MonoBehaviour
{
    [SerializeField] private GameObject camaraAerea;
    [SerializeField] private GameObject personaje;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            camaraAerea.SetActive(false);
            personaje.SetActive(true);
        }
    }
}
