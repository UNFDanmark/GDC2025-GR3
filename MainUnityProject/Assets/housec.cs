    using UnityEngine;

public class housec : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void LateUpdate()
    {
        
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
        //(pSS.myState == PlayerScript.State.ATTACHED
        
        
        
        
        
    }
}
