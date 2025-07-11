using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;
    public int health = 10;
    public int dih = 14;
    string navn = "Wilson";
    bool has_erection = true;
    public float speed = 20f;
    public float dihCooldown = 1;

    public InputAction moveAction;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.GetComponent<Rigidbody>();
        moveAction.Enable();


    }

    // Update is called once per frame
    void Update()
    {

        Vector2 moveInput = moveAction.ReadValue<Vector2>();

        Vector3 newVelocity = rb.linearVelocity;

        newVelocity.x = moveInput.x * speed;
        newVelocity.z = moveInput.y * speed;

        rb.linearVelocity = newVelocity;
        

    }
}
 