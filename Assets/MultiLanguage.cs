using Assets.SimpleLocalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiLanguage : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetString("lang","Spanish");
        switch (Application.systemLanguage)
        {
            case SystemLanguage.English:
                LocalizationManager.Language = "English";
                break;
            case SystemLanguage.Spanish:
                LocalizationManager.Language = "Spanish";
                break;
        }
    }
    void Update()
    {

        LocalizationManager.Language = PlayerPrefs.GetString("lang");
        
        
    }

    public void Language(string language)
    {
        LocalizationManager.Language = language;
        PlayerPrefs.SetString("lang", language);
    }
}