using UnityEngine;

public class interactor : MonoBehaviour
{

    public Transform Interactorsource;

    public float InteractRange;
    //we didnt steal this from youtube i pwomise >_<
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    interface IInteractable
    {
        public void interact()
        {
            print("it worked!!");
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {



            Ray r = new Ray(Interactorsource.position, Interactorsource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.interact();
                }
            }
        }
    }
}
