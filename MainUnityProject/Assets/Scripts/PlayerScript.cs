using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class PlayerScript : MonoBehaviour
{
    public CharacterController controller;
    
    public Transform cam;
    bool Gliding;
    public float speed = 6f;
    public float currentspeed;
    public GameObject grounded;
    private isgrounded iGG;
    public float turnSmoothTime = 0.4f;
    float _turnSmooth;
    public InputAction jumpAction; 
    private Vector3 PlayerVelo;

    public float jumpHeight = 5f;
    //gravity
    public float gravitySpeed = -9.81f;
   
   
    
   
   
    
    
    void Start()
    {
        jumpAction.Enable();
        iGG = GameObject.Find("isGrounded").GetComponent<isgrounded>();
        currentspeed = speed;
    }
    // Update is called once per frame
    void Update()
    {
        //simplified positions:
        float yPosition = transform.position.y;
        float xPosition = transform.position.x;
        float zPosition = transform.position.z;  
        //
        
        
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical);
        
        //Vector3 gravity = Vector3.down;
        //Vector3 movement = direction * speed + gravity * gravitySpeed;
        //transform.Translate(movement * Time.deltaTime, Space.World);    
        
        if (direction.magnitude >= 0.1f)
        {
            

        }

        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmooth, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        Vector3 moveDir = cam.forward;
        Vector3 finalMove = moveDir * (currentspeed * Time.deltaTime * vertical);
        finalMove.y = PlayerVelo.y * Time.deltaTime;
        controller.Move(finalMove);
        
        
        
        if (iGG.isGrounded && jumpAction.WasPressedThisFrame())
        {
            PlayerVelo.y = Mathf.Sqrt(jumpHeight * -3.0f * gravitySpeed);
            
        }

        if (!iGG.isGrounded)
        {
            currentspeed += 2f;
            currentspeed = Mathf.Clamp(currentspeed, speed, 8f);
            gravitySpeed = -7f;
        }
        if (iGG.isGrounded)
        {
            currentspeed = speed;
            gravitySpeed = -10f;
        }
        
        
        PlayerVelo.y += gravitySpeed * Time.deltaTime;
        
        
        
        //if (onHead)
        {
            
        }
        
        //if (topJump)
        {
            
            
            
        }
        
        
    }

    void OnTriggerEnter(Collider other)
    {
        
    }
}
 