using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshPro))]
public class LocalizationText : MonoBehaviour
{
    public string LocalizationKey;

    public void Start()
    {
        Localize();
    }

    private void Localize()
    {
        GetComponent<TextMeshPro>().text = LocalizationManager.Localize(LocalizationKey);
    }
}