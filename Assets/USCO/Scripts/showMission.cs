using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class showMission : MonoBehaviour
{
    public int Mission;
    [SerializeField] public TMP_Text mision;

    void Start()
    {
       //mision.text = LocalizationManager.Localize("[MapUiMision"+Mission+"]");
    }
}
