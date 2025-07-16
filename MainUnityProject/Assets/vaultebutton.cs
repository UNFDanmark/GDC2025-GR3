using UnityEngine;

public class vaultebutton : MonoBehaviour
{
    
    PlayerScript pSS;
    public GameObject image;
    public GameObject canvasObject;

    attachplayer ap;
    public GameObject trigger;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //image.SetActive(false);
        ap = trigger.GetComponent<attachplayer>();
        pSS = GameObject.FindWithTag("GameController").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
        //(pSS.myState == PlayerScript.State.ATTACHED
        
        
        
        
        
    }
    
    void Update()
    {
        if ( ap.isInBox){
                
            image.SetActive(true);
        }
      
        
        
            
            
        
        
        
      
    }
}