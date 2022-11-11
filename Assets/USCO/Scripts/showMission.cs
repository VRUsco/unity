using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class showMission : MonoBehaviour
{
    void Start()
    {
        Load();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Load()
    {
        string path = Path.Combine("playerInfo", "playerMissions.data");
        Debug.Log(path);

        string missionsJson = File.ReadAllText(path);
        Debug.Log(missionsJson);

        object missions = JsonUtility.FromJson<Object>(missionsJson);

        Debug.Log(missions);
    }
}