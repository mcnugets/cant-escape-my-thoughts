using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.UI;

public class charController : MonoBehaviour
{
    //movement controls
    public float speed;
    private Rigidbody rb;

    public useItemManager UIM;
   

    //mouse controls
    public float sensitivity;
    public float smoothing;
    public Transform camera;
    public GameObject inventoryUI;

    #region booleans
    private bool isMouseVisible;
    public bool isWalking;
    private bool isinvOpen;
    #endregion

    //   private inventory inv;



    // Start is called before the first frame update
    private float walkingSpeed;
    
  
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
       
       
        rb = GetComponent<Rigidbody>();
        camera = GameObject.FindWithTag("MainCamera").GetComponent<Transform>();
        isinvOpen = false;
        inventoryUI.SetActive(isinvOpen);
        //inv = gameObject.GetComponent<inventory>();
        walkingSpeed = speed;
        isWalking = false;
    }

  


    // Update is called once per frame
    void Update()
    {
     
       
       //controls
        charMovement();
        sprint();
        interact();

        if(!isMouseVisible)
        mouseConrtols();

        openInventory();
        // DropItem();


    }
    private void sprint() 
    {
       
        if (Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            float speedMultiplier = 2f;
            speed = speedMultiplier * speed;
        }else
        if (Input.GetKeyUp(KeyCode.LeftShift)) 
        {
            speed = walkingSpeed;
            print("SPEED " + speed);
        }
    }
    void charMovement()
    {



        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal");
        Vector3 posX = transform.right * straffe;
        Vector3 posZ = transform.forward * translation;
        Vector3 sumOfVectors = posX + posZ;
        Vector3 playerVel = new Vector3(sumOfVectors.x, 0, sumOfVectors.z);

        rb.velocity = playerVel;
        if(rb.velocity== Vector3.one * 0) 
        {
            isWalking = false;
        }
        else 
        {
            isWalking = true;
        }
    
    }

    void mouseConrtols() 
    {
       
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
     
        Vector2 mouseDir = new Vector2( mouseX, mouseY);
        Quaternion camereRotation = camera.localRotation;
        Quaternion rigidbodyRotation = rb.rotation;





        
        float clampRotation = -mouseDir.y;
        clampRotation = Mathf.Clamp(clampRotation, -90f, 90f);
        camereRotation.eulerAngles = new Vector3(camereRotation.eulerAngles.x, clampRotation);
       



        camera.localRotation = camereRotation *  Quaternion.AngleAxis(camereRotation.eulerAngles.y, Vector3.right) ;
        rb.rotation = rigidbodyRotation * Quaternion.AngleAxis(mouseDir.x, Vector3.up);
        
      
        
        
        
    }
    void openInventory() 
    {
        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            isinvOpen = !isinvOpen;
            inventoryUI.SetActive(isinvOpen);


            if (Cursor.lockState == CursorLockMode.Locked)
            {
                isMouseVisible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else 
            {
                isMouseVisible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }

        }


    }
    void interact() 
    {
        for (int i = 0; i < UIM.theDoors.Count; i++)
        {
            GameObject doorGame_Object = UIM.theDoors[i];

            door Door = doorGame_Object.GetComponent<door>();
            
            if (Input.GetKeyDown(KeyCode.E) && Door.inTrigger)
            {
               
                Door.Open = !Door.Open;
                Door.Close = !Door.Close;
               

            }

            print("DOOR OPEN==> " + Door.Open);

        }
       
    } 
   

 



}
