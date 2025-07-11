using UnityEngine;
using UnityEngine.InputSystem;

public class RotateScript : MonoBehaviour
{

    public InputAction rotateAction;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rotateAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        
        float rotation = rotateAction.ReadValue<float>();
        

        transform.Rotate(0, rotation, 0);
        
        
        
        
        
    }
}
