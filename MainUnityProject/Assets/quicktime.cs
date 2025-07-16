using System;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Splines.ExtrusionShapes;
using UnityEngine.UI;

public class quicktime : MonoBehaviour
{
    public float vaultspeed = 4;
    public TMP_Text textbox;
    public RectTransform tack;
    int direction;
    public float startspeed = 300;
    public float speed;
    public int hitstotal = 4;
    int hitsleft = 4;
    
    
    //getting canvas
    public GameObject quicktimecanvas;

    public Transform target;
    public Transform vault;
    
    
    
    public UnityEngine.UI.Button HitButton;
    
    float x;

   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vaultspeed = 10;
        hitsleft = hitstotal;
       /* CanvasGroup group = canvas.GetComponent<CanvasGroup>();
        if (group == null)
        {
            group = canvas.gameObject.AddComponent<CanvasGroup>();
        }
        */
        
        direction = 1;
        hitsleft = hitstotal;
        
        Button btn = HitButton.GetComponent<Button>();
        btn.onClick.AddListener(checkHit);
    }

    // Update is called once per frame
    void Update()
    {
        
       float step = vaultspeed * Time.deltaTime;
        
        if (tack.anchoredPosition.x >= 500)
        {
            direction = -1;
        }
        else if (tack.anchoredPosition.x <= -500)
        {
            direction = 1;
        }
        
        tack.anchoredPosition += new Vector2(direction*speed * Time.deltaTime, 0);
        
        
      x = tack.anchoredPosition.x;

      if (hitsleft <=0)
      {

          //vault.position = new Vector3(100, 100, 100);
         
          vault.position = Vector3.MoveTowards(vault.position, target.position, step);


          if (vault.position == target.position)
          {
              quicktimecanvas.SetActive(false);
          }
          
      }

    }

    /*void FixedUpdate()
    {
        mousewaspressed = false;
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            mousewaspressed = true;
        }

        if (mousewaspressed && (x < 50))
        {
            speed += 250;
            hitsleft -= 1;
        }
        else if (mousewaspressed && !((x > -50) && ( x < 50) ))
        {
            print("ehh wrong");
            hitsleft = hitstotal;
            speed = startspeed;
        }

        textbox.text = $"{hitsleft}";
    }
    */
   public void checkHit()
    {
        

        if (((x > -50) && ( x < 50)))
        {
            speed += 150;
            hitsleft -= 1;
        }
        else if (!((x > -50) && ( x < 50) ))
        {
            print("ehh wrong");
            hitsleft = hitstotal;
            //hitsleft -= 1;
            speed = startspeed;
        }

        textbox.text = $"{hitsleft}";
    }
    
    
    
}
