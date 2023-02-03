using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using StarterAssets;

public class DialogueScript : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public FirstPersonController Controller;

    public string key;

    //public String[] Lines;

    public float textSpeed = 0.1f;

    int index;

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

        index = 0;
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
