using System;
using UnityEngine;
using UnityEngine.AI;

public class attachplayer : MonoBehaviour
{

    public bool attachable;
    public bool isInBox;
    private GameObject player1;
    PlayerScript pSS;
    public bool isjumping;
    private isgrounded iGG;
    public bool isattached;

    public bool isGuard;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isattached = false;
        attachable = true;
        iGG = GameObject.Find("isGrounded").GetComponent<isgrounded>();
        player1 = GameObject.FindWithTag("GameController");
        pSS = GameObject.FindWithTag("GameController").GetComponent<PlayerScript>();
        isInBox = false;
        
    }


    void Update()
    {
        isInBox = false;
        Collider[] colliderS = new Collider[32];
        int antal2 = Physics.OverlapBoxNonAlloc(transform.position, transform.localScale,colliderS);
        

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
                isattached = true;
            }
        }
        
        if (isattached)
        {
            player1.transform.position = transform.position;
            player1.transform.rotation = transform.rotation * Quaternion.AngleAxis(90, Vector3.up);
            attachable = false;
            player1.tag = "Untagged";

            if (isGuard)
            {
                pSS.myState = PlayerScript.State.ATTACHEDGUARD;
            }
            else
            {
                pSS.myState = PlayerScript.State.ATTACHED;
            }

            if (pSS.jumpAction.WasPressedThisFrame())
            {
                attachable = true;
                isattached = false;
                pSS.EE = false;
                pSS.PlayerVelo.y = Mathf.Sqrt(pSS.jumpHeight * -3.0f * pSS.gravitySpeed);
                pSS.currentspeed += 1.5f;
                isInBox = false;
                pSS.myState = PlayerScript.State.NOT_ATTACHED;
                player1.tag = "GameController";
            }
        }
        
    }

    
    
    
}