using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{

    private List<GameObject> itemCollider;
    private bool onEnnter;
    private item collideditem;
    public inventory Inventory;
   
    // Start is called before the first frame update
    void Start()
    {
        itemCollider = new List<GameObject>();

        onEnnter = false;
       // Inventory = gameObject.GetComponent<inventory>();
        collideditem = new item();

    }
    public bool onEnter
    {
        get { return onEnnter; }
        set { onEnnter = value; }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
   
    private void OnTriggerEnter(Collider other)
    {


        if (other.tag == "item")
        {
            var collideditem2 = other.GetComponent<ItemGameObject>();
            collideditem2.ItemGM.itemName = other.gameObject.name;

            //Debug.Log("CHECKING GAME OBJECT " + collideditem.sourceObject);
            if (!Inventory.HasThisItem(collideditem2.ItemGM.itemName))
            {
                Inventory.AddItem(collideditem2.ItemGM);


                if (!itemCollider.Contains(other.gameObject))
                {
                    itemCollider.Add(other.gameObject);






                    onEnter = true;
                    for (int x = 0; x < itemCollider.Count; x++)
                    {
                        if (x == itemCollider.Count - 1)
                        {




                            Destroy(itemCollider[x].gameObject);


                            itemCollider.RemoveAt(x);

                            if (Inventory.instatiatedPrefab.Length > 0)
                            {

                            }
                        }
                    }
                }
               





            }
            else
            {
                print("SORRY THIS ITEM IS ALREDY IS IN THE INVENTORY))");
            }
        }



    }


}
