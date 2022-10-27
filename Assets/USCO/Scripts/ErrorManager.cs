using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ErrorManager : MonoBehaviour
{
    public int errores = 0;
    [SerializeField] public TMP_Text erroresUI;
    void Start()
    {
        erroresUI.text = errores.ToString();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //IncreaseError();
            Debug.Log("ERROR INCREMENTADO");
            IncreaseError();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            //DecreaseError();
            Debug.Log("G FUE PRESIONADA");
        }
    }

    private void IncreaseError()
    {
        errores++;
        erroresUI.text = errores.ToString();
    }
}
