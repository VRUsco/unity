using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    private bool isPaused;
    public static GameManager Instance { get; private set; }
    
    private void Awake(){
        if(Instance != null && Instance != this ){
            Destroy(this);
        }else{
            Instance = this;
        }
    }
    
    private void Update(){
        if(Input.GetKeyDown(KeyCode.P)){
            UpdatePause();
            ShowPausePanel();
        }
    }

    public bool isGamePaused(){
        return isPaused;
    }

    private void UpdatePause(){
        isPaused = !isPaused;
        if(isPaused){
            Time.timeScale = 0f;
        }else{
            Time.timeScale = 1f;
        }
    }
    private void ShowPausePanel(){
        if(isPaused){
            pauseMenu.SetActive(true);
        }else{
            pauseMenu.SetActive(false);
        }
    }


    public void ChangeScene(int Scene)
    {
        CargaNivel.NivelCarga(Scene);
    }
}

/* 
private void OnDisable()
        {
            m_Enabled = false;

            // Remove from global list.
            var index = ArrayHelpers.IndexOfReference(s_AllActivePlayers, this, s_AllActivePlayersCount);
            if (index != -1)
                ArrayHelpers.EraseAtWithCapacity(s_AllActivePlayers, ref s_AllActivePlayersCount, index);

            // Unhook from change notifications if we're the last player.
            if (s_AllActivePlayersCount == 0 && s_UserChangeDelegate != null)
                InputUser.onChange -= s_UserChangeDelegate;

            StopListeningForUnpairedDeviceActivity();
            StopListeningForDeviceChanges();

            // Trigger leave event.
            PlayerInputManager.instance?.NotifyPlayerLeft(this);

            ////TODO: ideally, this shouldn't have to resolve at all and instead wait for someone to need the updated setup
            // Avoid re-resolving bindings over and over while we disassemble
            // the configuration.
            using (InputActionRebindingExtensions.DeferBindingResolution())
            {
                DeactivateInput();
                UnassignUserAndDevices();
                UninitializeActions();
            }

            m_PlayerIndex = -1;
        } */