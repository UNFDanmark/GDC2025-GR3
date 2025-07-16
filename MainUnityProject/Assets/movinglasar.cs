using UnityEngine;

public class movinglasar : MonoBehaviour
{
    public Transform target;
    public float speed = 1.0f;
    new Vector3 OGpos;
    bool ismovingtoobject1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ismovingtoobject1 = true;
        OGpos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
        var step =  speed * Time.deltaTime;

        if (transform.position == target.position)
        {
            ismovingtoobject1 = false;
        }
        
        
        if(ismovingtoobject1){
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, OGpos, step);
        }

        if (OGpos == transform.position)
        {
            ismovingtoobject1 = true;
        }
        
        
        
    }
}
