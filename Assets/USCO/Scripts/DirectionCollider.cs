using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DirectionCollider : MonoBehaviour
{
    public string direction;
    [SerializeField] private TMP_Text directionUI;

    private void OnTriggerEnter(Collider obj)
    {
        SaveManager save = FindObjectOfType<SaveManager>();

        if (obj.tag == "PlayerController")
        {
            directionUI.text = "Estás en: \n"+direction;
            save.updateDirection(direction);
        }
    }
}
