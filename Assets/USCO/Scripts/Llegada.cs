using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llegada : MonoBehaviour
{
    [SerializeField] private GameObject endScreen;
    [SerializeField] private GameObject interfacePlayer;
    public SaveManager save;
    public AudioSource audioLlegada;
    public AudioSource audioAmbiente;

    private void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "PlayerController")
        {
            audioLlegada.Play();
            audioAmbiente.Pause();
            interfacePlayer.SetActive(false);
            endScreen.SetActive(true);
            GameManager.Instance.UpdatePause();
            if (save)
            {
                save.SaveAppAsync();
            }
        }
    }
}
