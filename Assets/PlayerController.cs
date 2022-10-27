using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private float horizontalMove;
    private float verticalMove;
    public CharacterController player;
    private Vector3 playerInput;
    public float _gravity = 9.8f;
    public float _speed = 3.0f;

    private Vector3 directionPlayer;
    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;

    public NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
        navMeshAgent = GetComponent<NavMeshAgent>(); 

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

