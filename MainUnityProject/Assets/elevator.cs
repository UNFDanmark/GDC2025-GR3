using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class elevator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        print("high other");
        if (other.CompareTag("CART"))
        {
            print("hej cart");
            SceneManager.LoadScene("VAULT");
        }
        
    }
}
