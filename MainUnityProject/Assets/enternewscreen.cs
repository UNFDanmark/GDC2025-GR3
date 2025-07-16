using System;
using UnityEngine;

public class Enternewscreen : MonoBehaviour
{
    PlayerScript pSS;
    public GameObject deathscreen;
    public GameObject winscreen;
    // private MonoBehaviour scriptToDisable;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pSS = GameObject.FindWithTag("GameController").GetComponent<PlayerScript>();
        winscreen.SetActive(false);
        deathscreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnControllerColliderHit(ControllerColliderHit colliderHit)
    {
        print(colliderHit.gameObject);
        print(colliderHit.gameObject.tag);
        
        if (colliderHit.gameObject.CompareTag("DEADLY"))
        {
           deathscreen.SetActive(true);
            pSS.enabled = false;

        } else if (colliderHit.gameObject.CompareTag("win"))
        {
            
            pSS.enabled = false;
            winscreen.SetActive(true);
        }
    }
}
