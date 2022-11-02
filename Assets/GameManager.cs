using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int SceneNumber;
    public void ChangeScene()
    {
        SceneManager.LoadScene(SceneNumber);
    }
}


