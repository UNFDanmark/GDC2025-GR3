using System;
using UnityEngine;

public class attach2 : MonoBehaviour
{
    
    
    
    private GameObject player;
    PlayerScript pSS;
    public bool isattached = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("GameController");
        pSS = GameObject.FindWithTag("GameController").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            print("E");
        }
        if (isattached)
        {
            player.transform.position = transform.position;
            player.transform.rotation = transform.rotation;

            if (pSS.jumpAction.WasPressedThisFrame())
            {
                isattached = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (pSS.pressE.WasPressedThisFrame() && other.CompareTag("GameController"))
        {
            print("hello");
            isattached = true;
        }
    }
}
