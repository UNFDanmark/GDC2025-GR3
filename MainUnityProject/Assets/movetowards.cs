using UnityEngine;

public class movetowards : MonoBehaviour
{
    public Transform target;
    float timer=1f;
    float currenttimer;
    PlayerScript pSS;
    
    public float lerpspeed = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pSS = GameObject.FindWithTag("GameController").GetComponent<PlayerScript>();
        currenttimer = timer;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (pSS.myState == PlayerScript.State.ATTACHNONHUMAN)
        {
            currenttimer -= Time.deltaTime;
        }

        if (pSS.myState == PlayerScript.State.ATTACHNONHUMAN && currenttimer <=0f)
        {
            Vector3 position = transform.position;
            position.z = Mathf.Lerp(position.z, target.position.z, lerpspeed * Time.deltaTime/100f );
            transform.position = position;
        }
        
    }
}
