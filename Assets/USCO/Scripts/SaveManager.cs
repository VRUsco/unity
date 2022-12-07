using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Text;
using System.IO;
using UnityEngine.Networking;

public class SaveManager : MonoBehaviour
{
    public int errores = 0;
    [SerializeField] private TMP_Text erroresUI;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private float timeElapsed;
    [SerializeField] private GameObject endOfLevel;
    

    [SerializeField] private TMP_Text endOfLevelErrores;
    [SerializeField] private TMP_Text endOfLevelTiempo;
    public string time;
    private int minutes, seconds, miliseconds;
    private string directionToSave = "Cll 0 con 0";

    void Start(){
        erroresUI.text = errores.ToString();
    }

    void Update(){

        timeElapsed += Time.deltaTime;

        timerText.text = getTime(timeElapsed);

        if (minutes > 9)
        {
            timerText.color = new Color(255,0,0,255);
        }

        //Invoke("SaveApp", (10.0f * Time.deltaTime));
    }

    [ContextMenu("GUARDAR CHAMO")]
    public void SaveApp(){
        PlayerInfo player = new PlayerInfo();

        player.errores = errores;
        player.tiempo = time.ToString();
        player.direction = directionToSave;

        string playerInfoJson = JsonUtility.ToJson(player);
        Debug.Log("Info a guardar: "+playerInfoJson);

        //string path = Path.Combine(Application.persistentDataPath, "playerData.data");
        string path = Path.Combine("playerInfo", "playerData.data");
        File.WriteAllText(path, playerInfoJson);

        endOfLevelTiempo.text = time.ToString();
        endOfLevelErrores.text = errores.ToString();
        endOfLevel.SetActive(true);

    }

    public class PlayerInfo{
        public int errores;
        public string tiempo;
        public string direction;
    }

    public void IncreaseError(string whyerror = "pta madre")
    {
        errores++;
        erroresUI.text = whyerror;
    }
    private void DecreaseError(){
        errores--;
        erroresUI.text = errores.ToString();
    }

    public void updateDirection(string direction){
        directionToSave = direction;
    }
    string getTime(float n){
        minutes = (int)(timeElapsed / 60f);
        seconds = (int)(timeElapsed - (60f * minutes));
        miliseconds = (int)((timeElapsed - (int)timeElapsed) * 100f);
        time = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, miliseconds);
        return time;
    }

}
/* RVadmin
RVadmin2022 */
