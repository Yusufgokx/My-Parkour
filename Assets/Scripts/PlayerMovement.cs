using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{ 
    //Movement
    private CharacterController controller;
    public float speed;

    //Camera Controller 
    private float xRotation = 0f;
    public float mouseSensivity = 100f;

    //Jump and Gravity
    private Vector3 velocity;
    private float gravity=-9.81f;
    private bool isGround;

    public Transform graundChecker;
    public float graundCheckerRadius;
    public LayerMask obstacleLayer;

    public float jumpheight = 0.1f;
    public float gravityDivide = 100f;

    public void Awake()
    {
        controller = GetComponent<CharacterController>();

        Cursor.visible=false; //mouse  simgesinin görülmesini engeller 
        Cursor.lockState = CursorLockMode.Locked; // mouse ne kadar hareket ederse etsın ortaya sabitler 
    }
    
    void Update()
    {
        //Movement
        Vector3 moveInputs = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
        Vector3 moveVelocity = moveInputs * Time.deltaTime * speed;

        controller.Move(moveVelocity);

        //Camera Controller
        transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensivity,0);
        xRotation -= Input.GetAxis("Mouse Y");
        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        xRotation = Mathf.Clamp(xRotation, -90, 90f);
        isGround = Physics.CheckSphere(graundChecker.position, graundCheckerRadius, obstacleLayer);
        print(isGround);

        //Jump and Gravity
        if(!isGround)
        {
            velocity.y += gravity * Time.deltaTime/gravityDivide;
        }
        else
        {
            velocity.y = -0.05f;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            velocity.y = Mathf.Sqrt(0.01f * -2f * gravity/gravityDivide) ;

        }

        controller.Move(velocity);
    }
}
