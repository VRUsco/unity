using UnityEngine;
using TMPro;
using System.IO;
using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

public class SaveManager : MonoBehaviour
{
    public string usuario = "Pedro Picapiedra";
    public int errores = 0;
    private int TiempoEnIrseElMensaje = 3;
    [SerializeField] private TMP_Text erroresUI;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private float timeElapsed;
    [SerializeField] private GameObject endOfLevel;


    [SerializeField] private TMP_Text endOfLevelErrores;
    [SerializeField] private TMP_Text endOfLevelTiempo;
    public string time;
    private int minutes, seconds, miliseconds;
    private string directionToSave = "Cll 0 con 0";

    void Start()
    {

    }

    void Update()
    {

        timeElapsed += Time.deltaTime;

        timerText.text = getTime(timeElapsed);

        if (minutes > 9)
        {
            timerText.color = new Color(255, 0, 0, 255);
        }



        //Invoke("SaveApp", (10.0f * Time.deltaTime));
    }

    [ContextMenu("GUARDAR CHAMO")]
    public void SaveAppAsync()
    {
        PlayerInfo player = new PlayerInfo();

        player.usuario = usuario;
        player.errores = errores.ToString();
        player.tiempo = time.ToString();
        /*player.direction = directionToSave;
        player.nivel = "1"; // TODO: make it responsive xD */


        string playerInfoJson = JsonUtility.ToJson(player);
        Debug.Log("Info a guardar: " + playerInfoJson);

        //string path = Path.Combine(Application.persistentDataPath, "playerData.data");
        string path = Path.Combine("playerInfo", "playerData.data");
        File.WriteAllText(path, playerInfoJson);

        var httpClient = new HttpClient();

        var json = JsonConvert.SerializeObject(player);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        var url = "http://localhost:5000/usuario";
        httpClient.PostAsync(url, data);

        //listaUno();
        lista();

        endOfLevelTiempo.text = time.ToString();
        endOfLevelErrores.text = errores.ToString();
        endOfLevel.SetActive(true);

       

        //HttpResponseMessage response = await client.GetAsync("http://localhost:5000/list");
        //response.EnsureSuccessStatusCode();
        //var responseBody = await response.Content.ReadAsStringAsync();
        //var result = JsonConvert.DeserializeObject<List<listado>>(responseBody);
        //Debug.Log("hola");

        /*HttpResponseMessage resulto = await client.GetStringAsync("http://localhost:5000/list");
        var dato = await resulto.Contains.
        //listado result = JsonConvert.DeserializeObject<listado>(resulto);
        Debug.Log(result);*/
    }

    public async Task lista()
    {
        var url2 = "http://localhost:5000/list";
        //var url2 = "https://jsonplaceholder.typicode.com/todos";
        HttpClient client = new HttpClient();
        var json2 = await client.GetStringAsync(url2);
        json2 = json2.Replace("\\","");
        json2 = json2.Replace("\"[", "[");
        json2 = json2.Replace("]\"", "]");
        var myDetails = JsonConvert.DeserializeObject<List<listado>>(json2);
        foreach (var item in myDetails)
        {
            Debug.Log(item.id);
            Debug.Log(item.usuario);
            Debug.Log(item.puntaje);
            Debug.Log("");
        }

    //https://jsonplaceholder.typicode.com/todos
    }

    public async Task listaUno()
    {
        var url2 = "http://localhost:5000/list/1";
        //var url2 = "https://jsonplaceholder.typicode.com/todos";
        HttpClient client = new HttpClient();
        var json2 = await client.GetStringAsync(url2);
        json2 = json2.Replace("\\", "");
        json2 = json2.Replace("\"[", "");
        json2 = json2.Replace("]\"", "");
        var item = JsonConvert.DeserializeObject<listado>(json2);
        Debug.Log(item.id);
            Debug.Log(item.usuario);
            Debug.Log(item.puntaje);
            Debug.Log("");

        //https://jsonplaceholder.typicode.com/todos
    }

    public class listado
    {
        public int id { get; set; }
        public string usuario { get; set; }
        public string puntaje { get; set; }
    }

    public class PlayerInfo
    {
        public string usuario;
        public string errores;
        public string tiempo;
        public string direction;
        public string nivel;
    }

    public void IncreaseError(string whyerror)
    {
        errores++;

        erroresUI.text = whyerror;
        Invoke("Cono", (200 * Time.deltaTime));

    }
    public void Cono()
    {
        erroresUI.text = "";
    }
    private void DecreaseError()
    {
        errores--;
        erroresUI.text = errores.ToString();
    }

    public void updateDirection(string direction)
    {
        directionToSave = direction;
    }
    string getTime(float n)
    {
        minutes = (int)(timeElapsed / 60f);
        seconds = (int)(timeElapsed - (60f * minutes));
        miliseconds = (int)((timeElapsed - (int)timeElapsed) * 100f);
        time = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, miliseconds);
        return time;
    }

    StringContent AsJson(object o)
    {
        return new StringContent(JsonConvert.SerializeObject(o), Encoding.UTF8, "application/json");
    }


}
/* RVadmin
RVadmin2022 */
