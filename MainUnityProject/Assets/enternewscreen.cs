using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Enternewscreen : MonoBehaviour
{
    PlayerScript pSS;
    public GameObject deathscreen;
    public GameObject winscreen;
        
    bool isdead;
    // private MonoBehaviour scriptToDisable;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isdead = false;
        pSS = GameObject.FindWithTag("GameController").GetComponent<PlayerScript>();
        winscreen.SetActive(false);
        deathscreen.SetActive(false);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (isdead)
        {
            
                if (pSS.pressE.WasPressedThisFrame())
                {
                    Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
                }
        }
    }


    void OnControllerColliderHit(ControllerColliderHit colliderHit)
    {
        //print(colliderHit.gameObject);
        print(colliderHit.gameObject.tag);
        
        if (colliderHit.gameObject.CompareTag("DEADLY"))
        {
           deathscreen.SetActive(true);
            pSS.enabled = false;
            isdead = true;


        } else if (colliderHit.gameObject.CompareTag("win"))
        {
            
            pSS.enabled = false;
            winscreen.SetActive(true);
        }
    }
}
