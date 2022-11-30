using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class showMission : MonoBehaviour
{
    public Mission mission;
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

        Mission missionLoaded = JsonUtility.FromJson<Mission>(missionsJson);
/* 
        mission.mssg = missionLoaded.mision;


        Debug.Log(missionLoaded); */
    }

}