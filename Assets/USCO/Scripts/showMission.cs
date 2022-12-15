using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class showMission : MonoBehaviour
{
    public int nMission = 1;
    [SerializeField] public TMP_Text mision; 

    private string[] missions = {};

private string[] directionMission = { "Cll2cr2", "Cll2cr2", "Cll2cr2" };
    void Start()
    {
        mision.text = missions[nMission];
    }
}