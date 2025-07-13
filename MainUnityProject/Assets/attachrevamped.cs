using System;
using UnityEngine;
using UnityEngine.AI;

public class attachrevamped : MonoBehaviour
{





    public Transform newParent;
    public Transform newParent2;
    public Transform child;
    public bool isInBox;
    private GameObject player1;
    PlayerScript pSS;
    private GameObject Human;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player1 = GameObject.FindWithTag("GameController");
        pSS = GameObject.FindWithTag("GameController").GetComponent<PlayerScript>();
        Human = GameObject.FindWithTag("Human");
        
        newParent = player1.transform;
        newParent2 = Human.transform;

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
                for (int i = 0; i < 1; i++)
                {
                    player1.transform.position = transform.position;
                    player1.transform.rotation = transform.rotation; 
                }
                TransferChild(newParent, child);
                
                if (pSS.jumpAction.WasPressedThisFrame())
                {
                    TransferChild(newParent2, child);
                    pSS.EE = false;
                    pSS.PlayerVelo.y = Mathf.Sqrt(pSS.jumpHeight * -3.0f * pSS.gravitySpeed);
                }
            } 
            
            
        }    
        
        
       
        
    }

    
    public void TransferChild(Transform newParent, Transform child)
    {
        child.SetParent(newParent);
        
    }
    
}