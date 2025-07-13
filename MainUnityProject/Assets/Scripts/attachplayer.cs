using System;
using UnityEngine;
using UnityEngine.AI;

public class attachplayer : MonoBehaviour
{






    public bool isInBox;
    private GameObject player1;
    PlayerScript pSS;
   
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        player1 = GameObject.FindWithTag("GameController");
        pSS = GameObject.FindWithTag("GameController").GetComponent<PlayerScript>();
    }


    void Update()
    {
        isInBox = false;
        Collider[] colliderS = new Collider[32];
        int antal2 = Physics.OverlapBoxNonAlloc(transform.position, (transform.localScale)*50,colliderS);
        

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

                if (pSS.jumpAction.WasPressedThisFrame())
                {
                    pSS.EE = false;
                }
            } 
            
            
        }    
        
        
       
        
    }

    
    
    
}