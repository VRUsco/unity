using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using StarterAssets;

public class DialogueScriptMulti : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject ControllerMouse;
    [SerializeField] private GameObject ControllerImage;
    [SerializeField] private GameObject ControllerW;
    [SerializeField] private GameObject ControllerS;
    [SerializeField] private GameObject ControllerA;
    [SerializeField] private GameObject ControllerD;
    [SerializeField] private GameObject Checkpoint;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private TMP_Text error;
    [SerializeField] private FirstPersonController Controller;
    [SerializeField] private string[] dialogueLines;
    [SerializeField] private AudioSource AudioPanel;

    float mouseX;
    float mouseY;

    [SerializeField] private float typingTime;
    private int lineIndex = 0;


    private void Start()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        
        StartDialogue();
    }

    private void Update()
    {

        switch (lineIndex)
        {
            case 0:
                if (Input.GetKeyUp(KeyCode.W))
                {
                    ControllerW.SetActive(false);
                    AudioPanel.Stop();
                    NextDialogueLine();
                }
                break;
            case 1:
                if (Input.GetKeyUp(KeyCode.S))
                {
                    ControllerS.SetActive(false);
                    AudioPanel.Stop();
                    NextDialogueLine();
                }
                break;
            case 2:
                if (Input.GetKeyUp(KeyCode.A))
                {
                    ControllerA.SetActive(false);
                    AudioPanel.Stop();
                    NextDialogueLine();
                }
                break;
            case 3:
                if (Input.GetKeyUp(KeyCode.D))
                {
                    ControllerD.SetActive(false);
                    AudioPanel.Stop();
                    NextDialogueLine();
                    ControllerMouse.SetActive(true);
                }
                break;
            case 4: 
                //GameManager.Instance.UpdatePause();
                float mouseX2 = Input.GetAxis("Mouse X");
                float mouseY2 = Input.GetAxis("Mouse Y");
                if (mouseX != mouseX2 || mouseY != mouseY2)
                {
                    AudioPanel.Stop();
                    NextDialogueLine();
                    ControllerMouse.SetActive(false);
                    ControllerImage.SetActive(true);
                    error.text = "ERROR";
                    
                    Time.timeScale = 1f;
                }
                break;
            case 5:
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    Checkpoint.SetActive(true);
                    error.text = "";
                    AudioPanel.Stop();
                    NextDialogueLine();
                }
                break;
            case 6:
                break;
            case 7:
                break;

            default:
                if (!ControllerW.activeSelf && !ControllerA.activeSelf && !ControllerS.activeSelf && !ControllerD.activeSelf)
                {
                    ControllerImage.SetActive(false);
                    AudioPanel.Stop();
                    NextDialogueLine();
                }
                break;
        }
    
    }

    private void StartDialogue()
    {
        StartCoroutine(ShowLine());
    }

    public void NextDialogueLine()
    {
        lineIndex++;
        if(lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            dialoguePanel.SetActive(false);
            StopAllCoroutines();
            Controller.enabled = true;
        }
    }

    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;
        AudioPanel.PlayOneShot(LocalizationManager.LocalizeAudio(dialogueLines[lineIndex]));
        foreach (char ch in LocalizationManager.Localize(dialogueLines[lineIndex]))
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(0.005f);
        }
    }
    void LimpiarDialogue()
    {
        dialogueText.text = "";
        dialoguePanel.SetActive(false);
        AudioPanel.Stop();
    }
    public void StartDialogueMovementCheckPoint(string keyLlegada)
    {
        LimpiarDialogue();
        dialoguePanel.SetActive(true);
        StartCoroutine(WriteLineCheckPoint(keyLlegada));
        AudioPanel.PlayOneShot(LocalizationManager.LocalizeAudio(keyLlegada));
       
    }
    IEnumerator WriteLineCheckPoint(string keyLlegada)
    {
        string Line = LocalizationManager.Localize(keyLlegada);
        foreach (char letter in Line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSecondsRealtime(0.005f);
        }
    }
}
