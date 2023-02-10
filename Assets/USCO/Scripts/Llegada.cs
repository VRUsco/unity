using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llegada : MonoBehaviour
{
    [SerializeField] private GameObject endScreen;
    [SerializeField] private GameObject interfacePlayer;
    public SaveManager save;

    private void OnTriggerEnter(Collider obj)
    {
        interfacePlayer.SetActive(false);
        GameManager.Instance.UpdatePause();
        save.SaveAppAsync();
    }
}
