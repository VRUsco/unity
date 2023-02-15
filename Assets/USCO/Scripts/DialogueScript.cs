using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using StarterAssets;

public class DialogueScript : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI TextContinue;
    public FirstPersonController Controller;
    [SerializeField] private GameObject dialoguePanel;

    public string key;
    public float textSpeed = 0.5f;

    void Start()
    {
        StartDialogue();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            StopAllCoroutines();
            dialogueText.text = LocalizationManager.Localize(key);
            TextContinue.text = LocalizationManager.Localize("[MapDialogueContinue]");
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            StopAllCoroutines();
            LimpiarDialogue();
            Controller.enabled = true;
            Time.timeScale = 1f;
        }
    }

    public void StartDialogue()
    {
        Time.timeScale = 0f;
        StartCoroutine(WriteLine());
        Controller.enabled = false;
    }
    public void StartDialogueMovement()
    {
        dialoguePanel.SetActive(true);
        StartCoroutine(WriteLine());
        Invoke("LimpiarDialogue", (500 * Time.deltaTime));
    }

    void LimpiarDialogue(){
        dialogueText.text = "";
        dialoguePanel.SetActive(false);
    }

    IEnumerator WriteLine()
    {
        string Line = LocalizationManager.Localize(key);
        foreach (char letter in Line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSecondsRealtime(textSpeed);
        }
    }

    public void StartDialogueMovementCheckPoint(string keyLlegada)
    {
        dialoguePanel.SetActive(true);
        StartCoroutine(WriteLineCheckPoint(keyLlegada));
        Invoke("LimpiarDialogue", (100 * Time.deltaTime));
    }
    IEnumerator WriteLineCheckPoint(string keyLlegada)
    {
        string Line = LocalizationManager.Localize(keyLlegada);
        foreach (char letter in Line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSecondsRealtime(textSpeed);
        }
    }
}
