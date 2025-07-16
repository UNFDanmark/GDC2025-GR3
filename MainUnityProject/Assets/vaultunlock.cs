using UnityEngine;

public class vaultunlock : MonoBehaviour
{   
    private GameObject player1;
    
    
    PlayerScript pSS;
    public bool isInBox;
    public GameObject quicktimecanvas;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player1 = GameObject.FindWithTag("GameController");
        quicktimecanvas.SetActive(false);
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
            if (currentCollider.CompareTag("GameController"))
            {
                isInBox = true;
                print("it worked btw ts");
            }
            
        }
    }
    
    void LateUpdate()
    {
        
        
        if (isInBox)
        {
            if (pSS.pressE.WasPressedThisFrame())
            {
               quicktimecanvas.SetActive(true);

            }
            
        }
        
    }
}