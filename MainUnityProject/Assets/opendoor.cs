using UnityEngine;

public class opendoor : MonoBehaviour
{   
    private GameObject player1;
    
    public GameObject glassdoor;
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
        int antal2 = Physics.OverlapBoxNonAlloc(transform.position, (transform.localScale)*5,colliderS);
        

        for (int i = 0; i < antal2; i++)
        {
            Collider currentCollider = colliderS[i];
            if (currentCollider.CompareTag("GUARD"))
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
                if (pSS.myState == PlayerScript.State.ATTACHEDGUARD)
                {
                    Destroy(glassdoor);
                }

            }
            
        }
        
    }
}