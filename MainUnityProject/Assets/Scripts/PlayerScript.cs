using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerScript : MonoBehaviour
{
    public CharacterController controller;
    
    public Transform cam;
    bool Gliding;
    public float speed = 4f;
    public float currentspeed;
    public GameObject grounded;
    private isgrounded iGG;
    public float turnSmoothTime = 0.4f;
    public float _turnSmooth;
    public InputAction jumpAction; 
    public Vector3 PlayerVelo;
    public InputAction pressE;
    public float jumpHeight = 5f;
    //gravity
    public float gravitySpeed = -9.81f;
    public InputAction walk;
    public bool EE;
    public bool isAttached;
    public float glidespeed_growth;
    public float glidemax = 3.5f;
    public float glideTime;
    public float t;
    public float t2;
    public float t3;
    public bool glide;
    public float glideSpeed;
    void Start()
    {
        pressE.Enable();
        walk.Enable();
        jumpAction.Enable();
        iGG = GameObject.Find("isGrounded").GetComponent<isgrounded>();
        currentspeed = speed;
        EE = false;
        glide = false;
    }
    // Update is called once per frame
    void Update()
    {
        //simplified positions:
        float yPosition = transform.position.y;
        float xPosition = transform.position.x;
        float zPosition = transform.position.z;  
        //

        if (!isAttached)
        {
            Vector2 bevægelse = walk.ReadValue<Vector2>();
            float horizontal = bevægelse.x;
            float vertical = bevægelse.y;
            Vector3 direction = new Vector3(horizontal, 0f, vertical);
            
            
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmooth, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = cam.forward;
            Vector3 finalMove = moveDir * ((currentspeed) * Time.deltaTime * vertical);
            //print($"finalMove: {finalMove}, moveDir: {moveDir}, currentspeed: {currentspeed}, vertical: {vertical}");
            finalMove.y = PlayerVelo.y * Time.deltaTime;
            controller.Move(finalMove);

        
        
        
        
            if (iGG.isGrounded && jumpAction.WasPressedThisFrame())
            {
                PlayerVelo.y = Mathf.Sqrt(jumpHeight * -3.0f * gravitySpeed);
            
            }

            if (!iGG.isGrounded && jumpAction.WasPressedThisFrame())
            {
                glide = true;
                
            }

            if (glide)
            {
                glideSpeed = 2.5f;
                gravitySpeed = -6f;
                //transform.forward
                currentspeed =  speed+glideSpeed;                                                                                                                                                                 
                
                
            }   
            if (iGG.isGrounded)
            {
                glideSpeed = 0f;
                glidespeed_growth = 0f;
                t = 0f;
                t2 = 0f;
                glide = false;
                currentspeed = speed;
                gravitySpeed =-10f;
            }
        
        
            PlayerVelo.y += gravitySpeed * Time.deltaTime;
            PlayerVelo.y = Mathf.Clamp(PlayerVelo.y,-10f,20f);
            
        }

        
        
        
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
 