using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject interfacePlayer;
    private bool isPaused;
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            UpdatePause();
            ShowPausePanel();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (isPaused)
            {
                SceneManager.LoadScene("Inicio");
            }
        }
    }

    public bool isGamePaused()
    {
        return isPaused;
    }

    public void UpdatePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    private void ShowPausePanel()
    {
        if (isPaused)
        {
            interfacePlayer.SetActive(false);
            pauseMenu.SetActive(true);
        }
        else
        {
            interfacePlayer.SetActive(true);
            pauseMenu.SetActive(false);
        }
    }


    public void ChangeScene(int Scene)
    {
        CargaNivel.NivelCarga(Scene);
    }

    public void Exit()
    {
        Application.Quit();
    }

}