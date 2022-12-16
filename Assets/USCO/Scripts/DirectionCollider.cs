using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DirectionCollider : MonoBehaviour
{
    public string Street;
    public string Career;
    [SerializeField] private TMP_Text StreetUI;
    [SerializeField] private TMP_Text CareerUI;

    void Start()
    {
        StreetUI = GetComponent<TMP_Text>();
        StreetUI.text = "puta";
    }
    private void OnTriggerEnter(Collider obj)
    {
        SaveManager save = FindObjectOfType<SaveManager>();

        if (obj.tag == "PlayerController")
        {
            StreetUI.text = Street;
            CareerUI.text = "#"+Career;
            //save.updateDirection(direction);
        }
    }
}
