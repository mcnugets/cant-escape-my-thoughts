using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    
    
    [HideInInspector] public bool inTrigger;
    
    Quaternion targetRotation;
    Quaternion startingRotation;


    private float currentLerpTime = 0f;
    private float LerpTime = 1f;
    public float speed;
    public bool Unlock;
    // Start is called before the first frame update
    private GameObject Door;



    public bool Lock
    {
        get; set;
    }

    
    public bool Open
    {
        get; set;
    }
    public bool Close 
    {
        get; set;
    }
    

    void Start()
    {
        Close = true;
        Open = false;
        Door = transform.Find("Hinge").gameObject;
        print("THE NAME OF THE DOOR " + Door.transform.parent.gameObject.name);
        targetRotation = Quaternion.Euler(Door.transform.localEulerAngles.x, Door.transform.localEulerAngles.y, -90f);
        startingRotation = Door.transform.localRotation;
        //from = savedPos;
       
       


    }

    
    // Update is called once per frame
    void Update()
    {
        checkDoorState();
    }

    
    void checkDoorState() 
    {
  

        if (Unlock)
        {
           

            if (Open && !Close)
            {

                currentLerpTime += Time.deltaTime * speed;

               

                if (currentLerpTime > 1f)
                {
                    currentLerpTime = 1f;
                }


            }

            if (!Open && Close)
            {
                currentLerpTime -= Time.deltaTime * speed;

                if (currentLerpTime < 0f)
                {
                    currentLerpTime = 0f;
                }

              

            }

            Door.transform.localRotation = Quaternion.Slerp(startingRotation, targetRotation, smoothstep());
           
        }
       
       
    }
    private float smoothstep() 
    {
        float time = currentLerpTime / LerpTime;
        time = time * time * (3f - 2f * time);
        return time;
    }

    
    private void OnTriggerEnter(Collider collision)
    {
        
        if(collision.tag == "Player") 
        {
            inTrigger = true;
           

        }
        
    }
    private void OnTriggerExit(Collider collision)
    {

        if (collision.tag == "Player")
        {
            inTrigger = false;
          
        }
    }

}
