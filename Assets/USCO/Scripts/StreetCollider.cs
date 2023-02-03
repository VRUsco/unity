using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using UnityEngine;

public class StreetCollider : MonoBehaviour
{
    private int idPruebaError;
    private TipoErrorId TipoErrorIdLegada;
    private async void OnTriggerEnter(Collider obj)
    {
        SaveManager save = FindObjectOfType<SaveManager>();

        if (obj.tag == "PlayerController")
        {
            DateTime fecha_hora = DateTime.Now;

            var url2 = "http://localhost:5000/error:\'CPI\'";
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(url2);
            json = json.Replace("[", "");
            json = json.Replace("]", "");
            TipoErrorIdLegada = JsonConvert.DeserializeObject<TipoErrorId>(json);
            idPruebaError = TipoErrorIdLegada.id;
            Debug.Log(idPruebaError);
            save.IncreaseError(LocalizationManager.Localize("[MapUiError]"), fecha_hora, idPruebaError);
        }
    }

    public class TipoErrorId
    {
        public int id;
    }
}
