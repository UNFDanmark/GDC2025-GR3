using System;
using UnityEngine;
using UnityEngine.AI;

public class attachtoguard : MonoBehaviour
{

    
    public bool isInBox;
    private GameObject player1;
    PlayerScript pSS;
    public bool isjumping;
    private isgrounded iGG;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        iGG = GameObject.Find("isGrounded").GetComponent<isgrounded>();
        player1 = GameObject.FindWithTag("GameController");
        pSS = GameObject.FindWithTag("GameController").GetComponent<PlayerScript>();
        
        
    }


    void Update()
    {
        isInBox = false;
        Collider[] colliderS = new Collider[32];
        int antal2 = Physics.OverlapBoxNonAlloc(transform.position, (transform.localScale)*5,colliderS);
        

        for (int i = 0; i < antal2; i++)
        {
            Collider currentCollider = colliderS[i];
            if (currentCollider.CompareTag("GameController"))
            {
                isInBox = true;
            }
            
        }

      

        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        
        if (isInBox)
        {
            if (pSS.pressE.WasPressedThisFrame())
            {
                pSS.EE = true;
            }
            
            if (pSS.EE == true)
            {
                
                player1.transform.position = transform.position;
                player1.transform.rotation = transform.rotation;
                pSS.myState = PlayerScript.State.ATTACHEDGUARD;
                if (pSS.jumpAction.WasPressedThisFrame())
                {
                    pSS.EE = false;
                    pSS.PlayerVelo.y = Mathf.Sqrt(pSS.jumpHeight * -3.0f * pSS.gravitySpeed);
                    pSS.currentspeed += 1.5f;

                    pSS.myState = PlayerScript.State.NOT_ATTACHED;
                }
            } 
            
            
        }    
        
        
       
        
    }

    
    
    
}