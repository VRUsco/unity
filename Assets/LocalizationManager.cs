using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;



public class LocalizationManager : MonoBehaviour
{

    static readonly Dictionary<string, string> myData = new Dictionary<string, string>();
    static List<string> missions = new List<string>();

    void Awake()
    {
        var culture = System.Globalization.CultureInfo.CurrentCulture;
        string language = culture.ToString().ToLower().Replace("-", "_");
        FileRead(language);
    }

    public static void ChangeLanguage()
    {
        myData.Clear();
    }

    public static void FileRead(string language)
    {
        string textFile = @"Assets/Language/mission_" + language + ".txt";
        if (File.Exists(textFile))
        {
            string[] lines = File.ReadAllLines(textFile);

            foreach (string line in lines)
            {
                int p = line.IndexOf("=");
                string key = line.Substring(0, p);
                string value = line.Substring(p + 1);
                key = key.Trim();
                value = value.Trim();
                myData.Add(key, value);
                missions.Add(value);
            }
        }
    }

    public static string Localize(string text)
    {
        string res = myData[text];
        return res;
    }
}
