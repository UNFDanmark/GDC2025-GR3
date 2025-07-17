using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerScript : MonoBehaviour
{

    public enum State
    {
        NOT_ATTACHED,GLIDING, ATTACHED, ATTACHNONHUMAN, ATTACHEDGUARD
    }
    
    public CharacterController controller;

    public State myState = State.NOT_ATTACHED;
    
    public float speed = 4f;
    public float currentspeed;
    public GameObject grounded;
    private isgrounded iGG;
    public float turnSmoothTimeGrounded = 0.4f;
    public float turnSmoothTimeGliding = 1.1f;
    
    public float _turnSmooth;
    public InputAction jumpAction; 
    public Vector3 PlayerVelo;
    public InputAction pressE;

    #region JumpingVariables
    public float jumpHeight = 5f;
    public float gravitySpeed = -9.81f;

    #endregion

    public Animator animator;
    public InputAction walk;
    public bool EE;
    public float t;
    public float t2;
    public float raise;
    
    public float glideSpeed;
    public float baseGlideSpeed;
    void Start()
    {
        pressE.Enable();
        walk.Enable();
        jumpAction.Enable();
        iGG = GameObject.Find("isGrounded").GetComponent<isgrounded>();
        currentspeed = speed;
        EE = false;
        
    }
    // Update is called once per frame
    void Update()
    {
        
        Vector3 finalMove = new Vector3();
        
        Vector2 bevægelse = walk.ReadValue<Vector2>();
        
        Vector3 direction = new Vector3(bevægelse.x, 0f, bevægelse.y);
        float angle=0f;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + transform.eulerAngles.y;
        
        animator.SetBool("grounded",iGG.isGrounded);
        if (myState == State.ATTACHED || myState == State.ATTACHEDGUARD || myState == State.ATTACHNONHUMAN)
        {
            animator.SetBool("grounded",true);
        } 
        
        
        if (myState == State.NOT_ATTACHED)
        {
            
            
            Vector3 moveDir = transform.forward;
            finalMove = moveDir * ((currentspeed) * Time.deltaTime * bevægelse.y);
            //print($"finalMove: {finalMove}, moveDir: {moveDir}, currentspeed: {currentspeed}, vertical: {vertical}");
            angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmooth, turnSmoothTimeGrounded);
            
            if (iGG.isGrounded && jumpAction.WasPressedThisFrame())
            {
                PlayerVelo.y = Mathf.Sqrt((jumpHeight) * -3.0f * gravitySpeed);
                animator.SetTrigger("takeoff");
                
            }

            if (!iGG.isGrounded && jumpAction.WasPressedThisFrame())
            {
                myState = PlayerScript.State.GLIDING;
                
            }
            
            if (iGG.isGrounded)
            {
                glideSpeed = 0f;
                t = 0f;
                t2 = 0f;
                currentspeed = speed;
                gravitySpeed =-10f;
            }
            
        }
        else if (myState == State.GLIDING)
        {
            
            
            if (bevægelse.y<0)
            {
                glideSpeed = -1.5f;
            }
            
            t += Time.deltaTime/4;
            raise = Mathf.Lerp(1.2f, 3f, t);
            t2 += Time.deltaTime*Mathf.Exp(raise)/2;
            gravitySpeed = Mathf.Lerp(-10f, -2f, t2);
            
            angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmooth, turnSmoothTimeGliding);
            finalMove = transform.forward * ((baseGlideSpeed+glideSpeed) * Time.deltaTime);

            if (iGG.isGrounded)
            {
                myState = State.NOT_ATTACHED;
            }
            
        }

        
        PlayerVelo.y += gravitySpeed * Time.deltaTime;
        PlayerVelo.y = Mathf.Clamp(PlayerVelo.y,-10f,20f);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        finalMove.y = PlayerVelo.y * Time.deltaTime;
        controller.Move(finalMove);
        
    }
}
 