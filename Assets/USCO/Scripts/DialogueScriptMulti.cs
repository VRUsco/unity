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
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private FirstPersonController Controller;
    [SerializeField] private string[] dialogueLines;

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
        //ControllerButton();
        float mouseX2 = Input.GetAxis("Mouse X");
        float mouseY2 = Input.GetAxis("Mouse Y");

        switch (lineIndex)
        {
            case 0:
                if (mouseX != mouseX2 || mouseY != mouseY2)
                {
                    NextDialogueLine();
                    ControllerMouse.SetActive(false);
                    ControllerImage.SetActive(true);
                    Time.timeScale = 1f;
                }
                break;
            case 1:
                if (Input.GetKeyUp(KeyCode.W))
                {
                    ControllerW.SetActive(false);
                    NextDialogueLine();
                }
                break;
            case 2:
                if (Input.GetKeyUp(KeyCode.S))
                {
                    ControllerS.SetActive(false);
                    NextDialogueLine();
                }
                break;
            case 3:
                if (Input.GetKeyUp(KeyCode.A))
                {
                    ControllerA.SetActive(false);
                    NextDialogueLine();
                }
                break;
            case 4:
                if (Input.GetKeyUp(KeyCode.D))
                {
                    ControllerD.SetActive(false);
                    NextDialogueLine();
                }
                break;
            default:
                if (!ControllerW.activeSelf && !ControllerA.activeSelf && !ControllerS.activeSelf && !ControllerD.activeSelf)
                {
                    ControllerImage.SetActive(false);
                    NextDialogueLine();
                }
                break;
        }
    
    }

    private void StartDialogue()
    {
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine()
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

        foreach(char ch in LocalizationManager.Localize(dialogueLines[lineIndex]))
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(0.005f);
        }
    }

    private void ControllerButton()
    {
        if (ControllerW.activeSelf || ControllerA.activeSelf || ControllerS.activeSelf || ControllerD.activeSelf)
        {
            if (Input.GetKeyUp(KeyCode.W))
            {
                ControllerW.SetActive(false);
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                ControllerA.SetActive(false);
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                ControllerS.SetActive(false);
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                ControllerD.SetActive(false);
            }
        }
        
    }
}
