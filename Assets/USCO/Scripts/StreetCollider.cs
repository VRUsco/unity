using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider obj)
    {
        SaveManager save = FindObjectOfType<SaveManager>();

        if (obj.tag == "PlayerController")
        {
            save.IncreaseError(LocalizationManager.Localize("[MapUiError]"));
        }
    }
}
