using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    public Light pointLightGreen;

    private string whoIsPlaying = "Player" ; // "ControllerCar"

    private void OnTriggerEnter(Collider obj)
    {
        SaveManager save = FindObjectOfType<SaveManager>();

        if (obj.tag == "ControllerCar" && pointLightGreen.enabled == true)
        {
            save.IncreaseError();
        }
    }
}
