using UnityEngine;

public class attachnonhuman : MonoBehaviour
{   
    private GameObject player1;
    PlayerScript pSS;
    public bool isInBox;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player1 = GameObject.FindWithTag("GameController");
        pSS = GameObject.FindWithTag("GameController").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        isInBox = false;
        Collider[] colliderS = new Collider[32];
        int antal2 = Physics.OverlapBoxNonAlloc(transform.position, (transform.localScale)*10,colliderS);
        

        for (int i = 0; i < antal2; i++)
        {
            Collider currentCollider = colliderS[i];
            if (currentCollider.CompareTag("GameController"))
            {
                isInBox = true;
            }
            
        }
    }
    
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
                pSS.myState = PlayerScript.State.ATTACHNONHUMAN;
            }
        }
        
    }
}

