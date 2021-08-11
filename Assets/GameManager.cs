using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private useItemManager uItemM;


    
    public GameObject interactUI;

    public bool boolUI;

    // Start is called before the first frame update
    void Start()
    {
        uItemM = GetComponent<useItemManager>();



        boolUI = false;

    }

    // Update is called once per frame
    void Update()
    {
        raycast();
    }


    public void raycast()
    {
        for (int i = 0; i < uItemM.theDoors.Count; i++)
        {
            RaycastHit hit;
            GameObject getDoorName = uItemM.theDoors[i].transform.Find("Hinge").transform.Find("Door").gameObject;
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            if (Physics.Raycast(ray, out hit) && hit.collider.name == getDoorName.transform.name)
            {


                door listDoors = uItemM.theDoors[i].GetComponent<door>();

                if (listDoors.inTrigger)
                {

                    boolUI = true;
                    

                }
            }
            else
            {
                boolUI = false;
                
            }
            interactUI.SetActive(boolUI);



        }
    }


}



