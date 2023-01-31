using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    [SerializeField] private GameObject Main_panel;
    [SerializeField] private GameObject Settings_Panel;
    [SerializeField] private GameObject New_Test_Panel;
    public TMPro.TMP_Dropdown AuxiliarDrop;
    public TMPro.TMP_Dropdown LevelsDrop;

    private void Start()
    {
        SearchAsync();
    }

    public void ChangePanel(string panel)
    {
        switch (panel)
        {
            case "new_test":
                Main_panel.SetActive(false);
                Settings_Panel.SetActive(false);
                New_Test_Panel.SetActive(true);
                break;
            case "settings":
                Main_panel.SetActive(false);
                Settings_Panel.SetActive(true);
                New_Test_Panel.SetActive(false);
                break;
            default:
                Main_panel.SetActive(true);
                Settings_Panel.SetActive(false);
                New_Test_Panel.SetActive(false);
                break;
        }
    }

    private async Task SearchAsync()
    {
        var url = "http://localhost:5000/auxiliares";
        HttpClient client = new HttpClient();
        var json = await client.GetStringAsync(url);
        json = json.Replace("\\", "");
        json = json.Replace("\"[", "[");
        json = json.Replace("]\"", "]");
        var auxiliares = JsonConvert.DeserializeObject<List<auxiliar>>(json);
        foreach (var item in auxiliares)
        {
            TMPro.TMP_Dropdown.OptionData m_NewData = new TMPro.TMP_Dropdown.OptionData();
            m_NewData.text = item.nombre.ToString();
            AuxiliarDrop.options.Add(m_NewData);
        }

        var url2 = "http://localhost:5000/level";
        var json2 = await client.GetStringAsync(url2);
        json2 = json2.Replace("\\", "");
        json2 = json2.Replace("\"[", "[");
        json2 = json2.Replace("]\"", "]");
        var levels = JsonConvert.DeserializeObject<List<level>>(json2);

        foreach (var item in levels)
        {
            TMPro.TMP_Dropdown.OptionData m_NewData = new TMPro.TMP_Dropdown.OptionData();
            m_NewData.text = item.nombre.ToString();
            LevelsDrop.options.Add(m_NewData);
        }
    }
    public class auxiliar
    {
        public int identificacion { get; set; }
        public string nombre { get; set; }
    }

    public class level
    {
        public int id { get; set; }
        public string nombre { get; set; }
    }
}
