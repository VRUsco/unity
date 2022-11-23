using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NivelControll : MonoBehaviour
{
    public GameObject Cars;

    public void DificultadNivel(int nivel)
    {
        if (nivel == 1)
        {
            Debug.Log("carros desactivados");
            Cars.SetActive(false);
        }
        else
        {
            Debug.Log("carros activados");
            Cars.SetActive(true);
        }
    }
}
