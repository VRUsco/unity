using Assets.SimpleLocalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiLanguage : MonoBehaviour
{
    private void Start()
    {
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
        //Debug.Log(PlayerPrefs.GetString("lang"));
        if (LocalizationManager.Language != "")
        {
            LocalizationManager.Language = PlayerPrefs.GetString("lang");
        }
        else
        {
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
        
    }

    public void Language(string language)
    {
        LocalizationManager.Language = language;
        PlayerPrefs.SetString("lang", language);
    }
}