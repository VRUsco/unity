using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class showMission : MonoBehaviour
{
    public int nMission = 1;
    [SerializeField] public TMP_Text mision; 

    private string[] missions = { "la gasolinera Terpel, calle 2 #2.",
                                 "la gasolinera Cafe, calle 2 #2.", 
                                "a gasolinera Exito, calle 2 #2." };

    private string[] directionMission = { "Cll2cr2", "Cll2cr2", "Cll2cr2" };
    void Start()
    {
        mision.text = "Dirígete a "+missions[nMission];
    }

    // Update is called once per frame
    void Update()
    {

    }


}