using System.Collections;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.InputSystem;


public class humancontroller : MonoBehaviour
{


    public InputAction walk1;
    PlayerScript pSS;
    public CharacterController controller1;
    public Vector3 PlayerVelo1;
    public attachplayer playerattach;
    public float timer = 1f;
    public float currentimer;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerattach = GetComponentInChildren<attachplayer>();
        pSS = GameObject.FindWithTag("GameController").GetComponent<PlayerScript>();
        walk1.Enable();
        currentimer = timer;
    }


    // Update is called once per frame
    void Update()
    {

        if ((pSS.myState == PlayerScript.State.ATTACHED || pSS.myState == PlayerScript.State.ATTACHEDGUARD) && (playerattach.isattached))
        {
            currentimer -= Time.deltaTime;
        }
        if (((pSS.myState == PlayerScript.State.ATTACHED || pSS.myState == PlayerScript.State.ATTACHEDGUARD) &&
             currentimer <= 0) && (playerattach.isattached))
        {
            pSS.gravitySpeed = -10f;
            
            pSS.currentspeed = 3f;
            Vector2 bevægelse1 = walk1.ReadValue<Vector2>();
            Vector3 direction1 = new Vector3(bevægelse1.x, 0f, bevægelse1.y);
        
            float targetAngle1 = Mathf.Atan2(direction1.x, direction1.z) * Mathf.Rad2Deg + transform.rotation.eulerAngles.y;
            float angle1 = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle1, ref pSS._turnSmooth, pSS.turnSmoothTimeGrounded);
            transform.rotation = Quaternion.Euler(0f, angle1, 0f);

            Vector3 moveDir1 = transform.forward;
            Vector3 finalMove1 = moveDir1 * (pSS.currentspeed * Time.deltaTime * bevægelse1.y);
            //print($"finalMove: {finalMove1}, moveDir: {moveDir1}, currentspeed: {pSS.currentspeed}, vertical: {bevægelse1.y}");
            finalMove1.y = PlayerVelo1.y * Time.deltaTime;
            controller1.Move(finalMove1);
        
        
            PlayerVelo1.y += pSS.gravitySpeed * Time.deltaTime;
            PlayerVelo1.y = Mathf.Clamp(PlayerVelo1.y,-10f,20f);

            

        }

        if (pSS.myState == PlayerScript.State.NOT_ATTACHED)
        {
            currentimer = timer;
        }
        
    }

    

    
    
}
