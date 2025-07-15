using UnityEngine;

public class movetowards : MonoBehaviour
{
    public Transform target;

    public float lerpspeed = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.z = Mathf.Lerp(position.z, target.position.z, lerpspeed * Time.deltaTime/100f );
        transform.position = position;
    }
}
