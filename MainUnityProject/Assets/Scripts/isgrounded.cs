using System;
using UnityEngine;

public class isgrounded : MonoBehaviour
{

    public bool isGrounded;
  

    // Update is called once per frame
    void Update()
    {
        isGrounded = false;
        Collider[] colliders = new Collider[2];
        int antal = Physics.OverlapBoxNonAlloc(transform.position, (transform.localScale)/2,colliders);
        

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
