using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject interfacePlayer;
    [SerializeField] private TMP_Dropdown Dropdown; // wire this in Inspector

    public static bool isPaused;
    public static bool isEnd = false;
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    private void Update()
    {
        if (!isEnd)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                UpdatePause();
                ShowPausePanel();
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (isPaused)
                ChangeScene("Home");
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
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
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

    public static void ChangeScene(string Scene)
    {
        isPaused = false;
        isEnd = false;
        CargaNivel.NivelCarga(Scene);
    }

    public void Exit()
    {
        Application.Quit();
    }
}