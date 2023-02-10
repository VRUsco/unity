using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public string key;
    [SerializeField] private GameObject ActualCheckpoint;
    [SerializeField] private GameObject NextCheckpoint;
    [SerializeField] private DialogueScript dialogue;
    private void OnTriggerEnter(Collider obj)
    {
        ActualCheckpoint.SetActive(false);
        NextCheckpoint.SetActive(true);
        dialogue.StartDialogueMovementCheckPoint(key);
    }
}
