using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public CharacterController controller;
    
    public Transform cam;
    bool Gliding;
    public float speed = 6f;
    public GameObject grounded;
    private isgrounded iGG;
    public float turnSmoothTime = 0.4f;
    float _turnSmooth;
    public InputAction jumpAction;
    
    
    
    void start()
    {
        jumpAction.Enable();
        iGG = GameObject.Find("isGrounded").GetComponent<isgrounded>();
    }
    // Update is called once per frame
    void Update()
    {
            
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical);
        
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmooth, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = cam.forward;
            controller.Move(moveDir * (speed * Time.deltaTime * vertical));
            
        }

        if (iGG.isGrounded && jumpAction.WasPressedThisFrame())
        {
            //controller.Move()
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
 