using System;
using UnityEngine;
using UnityEngine.UI;

public class isgrounded : MonoBehaviour
{

    public bool isGrounded;
    public LayerMask ignoreLayer;

    // Update is called once per frame
    void Update()
    {
        isGrounded = false;
        Collider[] colliders = new Collider[5];
        int antal = Physics.OverlapBoxNonAlloc(transform.position, (transform.localScale)/2,colliders,Quaternion.identity,~ignoreLayer );
        

        for (int i = 0; i < antal; i++)
        {
            Collider currentCollider = colliders[i];
            if (currentCollider.CompareTag("Ground"))
            {
                isGrounded = true;
            }
            
        }
        
        
    }
    
}
