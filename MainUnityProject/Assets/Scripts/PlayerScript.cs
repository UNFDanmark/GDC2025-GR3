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
    public float speed = 6f;
    public float currentspeed;
    public GameObject grounded;
    private isgrounded iGG;
    public float turnSmoothTime = 0.4f;
    float _turnSmooth;
    public InputAction jumpAction; 
    public Vector3 PlayerVelo;
    public InputAction pressE;
    public float jumpHeight = 5f;
    //gravity
    public float gravitySpeed = -9.81f;
    public InputAction walk;
    public bool EE;
    public float currentgravity;
    
   
   
    
    
    void Start()
    {
        pressE.Enable();
        walk.Enable();
        jumpAction.Enable();
        iGG = GameObject.Find("isGrounded").GetComponent<isgrounded>();
        currentspeed = speed;
        EE = false;
        currentgravity = gravitySpeed;
    }
    // Update is called once per frame
    void Update()
    {
        //simplified positions:
        float yPosition = transform.position.y;
        float xPosition = transform.position.x;
        float zPosition = transform.position.z;  
        //



        Vector2 bevægelse = walk.ReadValue<Vector2>();
        float horizontal = bevægelse.x;
        float vertical = bevægelse.y;
        Vector3 direction = new Vector3(horizontal, 0f, vertical);
        
        //Vector3 gravity = Vector3.down;
        //Vector3 movement = direction * speed + gravity * gravitySpeed;
        //transform.Translate(movement * Time.deltaTime, Space.World);    
        
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmooth, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        Vector3 moveDir = cam.forward;
        Vector3 finalMove = moveDir * (currentspeed * Time.deltaTime * vertical);
        print($"finalMove: {finalMove}, moveDir: {moveDir}, currentspeed: {currentspeed}, vertical: {vertical}");
        finalMove.y = PlayerVelo.y * Time.deltaTime;
        controller.Move(finalMove);

        
        
        
        
        if (iGG.isGrounded && jumpAction.WasPressedThisFrame())
        {
            PlayerVelo.y = Mathf.Sqrt(jumpHeight * -3.0f * currentgravity);
            
        }

        if (!iGG.isGrounded)
        {
            currentspeed += 2f;
            currentspeed = Mathf.Clamp(currentspeed, speed, 8f);
            currentgravity = gravitySpeed;
        }
        if (iGG.isGrounded)
        {
            currentspeed = speed;
            currentgravity = gravitySpeed;
        }
        
        
        PlayerVelo.y += currentgravity * Time.deltaTime;
        
        
        
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
 