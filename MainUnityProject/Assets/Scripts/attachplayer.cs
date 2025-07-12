using System;
using UnityEngine;
using UnityEngine.AI;

public class attachplayer : MonoBehaviour
{
  
 
   

   
    
    
    private GameObject player1;

   
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        player1 = GameObject.FindWithTag("GameController");
       
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //player1 = GameObject.Find("Player");
            
        player1.transform.position = transform.position;
        player1.transform.rotation = transform.rotation;
        
       
        
    }

    
    
    
}