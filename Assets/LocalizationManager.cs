using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;


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

    void Update()
    {

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
