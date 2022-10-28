using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    public Light pointLightGreen;

    private void OnTriggerEnter(Collider obj)
    {
        SaveManager save = FindObjectOfType<SaveManager>();

        if (obj.tag == "PlayerController" && pointLightGreen.enabled == true)
        {
            save.IncreaseError();
            Debug.Log("PUTO PASO PEATONAL");
        }
    }
}
