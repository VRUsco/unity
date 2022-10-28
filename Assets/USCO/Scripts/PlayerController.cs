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
        inputMovement.x = Input.GetAxis("Horizontal");
        inputMovement.y = Input.GetAxis("Vertical");

        inputRotation.x = Input.GetAxis("Mouse X") * sensibilidadMouse;
        inputRotation.y = Input.GetAxis("Mouse Y") * sensibilidadMouse;
    }

    private void FixedUpdate(){
        float vel = velCaminar;

        rb.velocity = transform.forward * vel * inputMovement.y + transform.right * vel * inputMovement.x;

        /* rotationXcamara -= inputRotation.y;
        rotationXcamara = Mathf.Clamp(rotationXcamara, -50, 50); 
        camara.localRotation = Quaternion.Euler(rotationXcamara, 0, 0);

        transform.rotation *= Quaternion.Euler( 0, inputRotation.x, 0);
         */
    }
}

/* public class PlayerController : MonoBehaviour
{
    private float horizontalMove;
    private float verticalMove;
    public CharacterController player;
    private Vector3 playerInput;
    public float _gravity = 9.8f;
    public float _speed = 1.0f;

    private Vector3 directionPlayer;
    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        playerInput = new Vector3(horizontalMove, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);
        camDirection();

        directionPlayer = playerInput.x * camRight + playerInput.z * camForward;
        directionPlayer = directionPlayer * _speed;

        
        player.transform.LookAt(player.transform.position + directionPlayer);
        Debug.Log(player.velocity.magnitude);
        SetGravity();
        player.Move(directionPlayer * Time.deltaTime);
    }

    void camDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;

    }

    void SetGravity()
    {
        directionPlayer.y = -_gravity * Time.deltaTime;
    }
}
 */