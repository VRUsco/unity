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

    public string key;
    public float textSpeed = 0.1f;

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
            gameObject.SetActive(false);
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

    IEnumerator WriteLine()
    {
        string Line = LocalizationManager.Localize(key);
        foreach (char letter in Line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSecondsRealtime(textSpeed);
        }
    }
}
