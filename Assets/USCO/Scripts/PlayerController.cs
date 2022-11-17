using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    Vector2 inputMovement;
    Vector2 inputRotation;
    Transform camara;
    float sensibilidadMouse = 4;
    float velCaminar = 10f;
    float rotationXcamara;
    void Start(){
        rb = GetComponent<Rigidbody>();
        camara = transform.GetChild(0);
        rotationXcamara = camara.eulerAngles.x;
    }

    void Update(){
        if(GameManager.Instance.isGamePaused()){
            Debug.Log("si entro");
            return;
        }else{
            Debug.Log("No entro");
        }
            

        
        inputMovement.x = Input.GetAxis("Horizontal");
        inputMovement.y = Input.GetAxis("Vertical");

        inputRotation.x = Input.GetAxis("Mouse X") * sensibilidadMouse;
        inputRotation.y = Input.GetAxis("Mouse Y") * sensibilidadMouse;
    }

    private void FixedUpdate(){
        float vel = velCaminar;

        rb.velocity = transform.forward * vel * inputMovement.y + transform.right * vel * inputMovement.x;
    }
}
