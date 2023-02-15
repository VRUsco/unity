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
        if (obj.tag == "PlayerController")
        {
            Debug.Log("entra");
            Debug.Log(obj);
            interfacePlayer.SetActive(false);
            GameManager.Instance.UpdatePause();
            save.SaveAppAsync();
        }
    }
}
