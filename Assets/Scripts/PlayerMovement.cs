using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{ 
    //Movement
    private CharacterController controller;
    public float speed;
    private float xRotation = 0f;
    public float mouseSensivity = 100f;

    public void Awake()
    {
        controller = GetComponent<CharacterController>();      
    }
    
    void Update()
    {
        //Movement
        Vector3 moveInputs = Input.GetAxis("Horizontal") * Vector3.right + Input.GetAxis("Vertical") * Vector3.forward;
        Vector3 moveVelocity = moveInputs * Time.deltaTime * speed;

        controller.Move(moveVelocity);
        //Camera Controller
        transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensivity, 0);
        xRotation -= Input.GetAxis("Mouse Y");

    }
}
