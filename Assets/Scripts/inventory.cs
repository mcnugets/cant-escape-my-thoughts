using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


[System.Serializable]
public class inventory : MonoBehaviour
{

    

    public List<item> items;


    public GameObject buttonPrefab;
    public RectTransform invenotoryPanel;

    public bool[] isTaken;
    public bool isFull = false;
    private float newYPos;

    public const int numbetOfSlots = 3;
    private static int isFullCounter = 0;

    [SerializeField] public ItemDataBase itemDB;
    public GameObject[] instatiatedPrefab;
    public useItemManager itemManager;
    // Start is called before the first frame update


    void Start()
    {

        
        newYPos = 0f;
        
        isTaken = new bool[numbetOfSlots];
        

        instatiatedPrefab = new GameObject[numbetOfSlots];
        if (itemDB.inventoryslot.Count == 0)
        {
            for (int x = 0; x < numbetOfSlots; x++)
            {
                isTaken[x] = false;
            }
        }
        else
        {
            LoadItems();

        }

        }
        private void LoadItems() 
    {
        
        itemDB.Load();
       
        for (int x = 0; x < itemDB.inventoryslot.Count; x++)
        {
            Vector2 buttonPos = new Vector2(buttonPrefab.transform.position.x, buttonPrefab.transform.position.y - newYPos);
            instantiate_menu_slot(x, buttonPos, itemDB.retrieveItem[x]);
            newYPos += buttonPrefab.transform.position.y / 2;
            isTaken[x] = true;
        }
        
        

    }
    private void CheckForKey(item checkforkey, Vector2 pos) 
    {         
           
        for (int x = 0; x < numbetOfSlots; x++)
        {


            if (!itemDB.retrieveItem.ContainsKey(x))
            {
                
                
                SendToInventoryDB(checkforkey, x);
                instantiate_menu_slot(x, pos, checkforkey);
                isTaken[x] = true;
                itemDB.Save();
                

            }
            else 
            {
                continue;
            }
            break;
            

        }
       
    }
    public bool HasThisItem(string getItemName)
    {
        for (int i = 0; i < itemDB.retrieveItem.Count; i++)
        {


            if (getItemName == itemDB.retrieveItem[i].itemName)
            {
                return true;
            }

        }
        return false;
    }

    public void SendToInventoryDB(item getItem, int getID) 
    {
        itemDB.retrieveItem.Add(getID, getItem);
        itemDB.retrireveID.Add(getItem, getID);
        itemDB.retrieveItem[getID].ID = getID;
        isFullCounter++;
        


    }
    public void instantiate_menu_slot(int x, Vector2 getPosition, item Item) 
    {
        instatiatedPrefab[x] = Instantiate(buttonPrefab, getPosition, Quaternion.identity);
        instatiatedPrefab[x].GetComponentInChildren<Text>().text = Item.itemName;
        instatiatedPrefab[x].GetComponent<inventorySlotUI>().getItem = Item;
        instatiatedPrefab[x].transform.SetParent(invenotoryPanel, false);

    }

    
    public bool checkForSlot(bool istaken) 
    {
        for (int i = 0; i < isTaken.Length; i++)
        {
            
            if(istaken) 
            {
                return true;
            }
        }
        return false;
    }
   
    public void AddItem(item newItem)
    {
        

        Vector2 buttonPos = new Vector2(buttonPrefab.transform.position.x, buttonPrefab.transform.position.y - newYPos);

        while (!isFull)
        {
            CheckForKey(newItem, buttonPos);
            break;
        }

        UpdateInventory();


        newYPos += buttonPrefab.transform.position.y / 2;


    }
    public void UpdateInventory() 
    {

        if (isFullCounter == numbetOfSlots)
        {
            isFull = true;
        }
        else 
        {
            isFull = false;
        }
        

        
    }


    public void DropItem(item DropItem)
    {

       
        foreach (var findByID in itemDB.retrireveID)
        {
            if(findByID.Value == DropItem.ID) 
            {

                GameObject spawnPrefab = Instantiate(itemDB.retrieveItem[findByID.Value].gameObjectPrefab, transform.position + transform.forward * 1f, Quaternion.identity);
                spawnPrefab.name = itemDB.retrieveItem[findByID.Value].gameObjectPrefab.name;


            }

        }
        if (DropItem)
        {
            RemoveItem(DropItem);
        }
        


    }
   
    public void UseItem(item useItem)
    {
        foreach (var ID in itemDB.retrireveID.Values)
        {
            if(ID == useItem.ID) 
            { //if player is iin the trigger
                itemDB.retrieveItem[ID].isUsed = true;
                
                itemDB.retrieveItem[ID].itemName = itemDB.retrieveItem[ID].itemName + "(USED)";
                instatiatedPrefab[ID].GetComponentInChildren<Text>().text = itemDB.retrieveItem[ID].itemName;
             if (itemDB.retrieveItem[ID].whichItem == itemType.Key) 
                {

                    Key key = (Key)itemDB.retrieveItem[ID];
                    itemManager.KeyManager(key);

                    //if is door 1 || 2 || 3 || 4
                    //if is in the trigger is player
                    //then activate the key for unlocking the door

                }
                if (itemDB.retrieveItem[ID].whichItem == itemType.Hint)
                {

                    Hint hint = (Hint)itemDB.retrieveItem[ID];
                    itemManager.HintManager(hint);

                }
            }
           
        }

    }

   
    public void RemoveItem(item RemoveItem)
    {
        int localIncrement = 0;

        int[] localAarray = new int[itemDB.retrieveItem.Count];
        foreach (var rettrieveitem in itemDB.retrieveItem)
        {

            localAarray[localIncrement] = rettrieveitem.Key;
            localIncrement++;

        }
        for (int i = 0; i < localAarray.Length; i++)
        {
            print(i + "  local arra-> " + localAarray[i]);
        }

       
        foreach (var array in localAarray)
        {
           Debug.Log("FOR EACH LOPOP IS WORKING MY GUY");
            // TEST THIS SHIT BOI
            if (array == RemoveItem.ID)
            {



                itemDB.retrireveID.Remove(itemDB.retrieveItem[array]);
                itemDB.retrieveItem.Remove(array);

                Destroy(instatiatedPrefab[array].gameObject);
                instatiatedPrefab[array] = null;
                isTaken[array] = false;
                isFullCounter--;

                UpdateInventory();

                itemDB.Save();

                break;
            }

            
        }

       

    }       
 




  /*  public void OnBeforeSerialize()
    {
        
    }

    public void OnAfterDeserialize()
    {
        for (int i = 0; i < inventoryslot.Length; i++)
        {
            inventoryslot[i].storedItem = itemDB.retrieveItem[inventoryslot[i].itemID];
        }
       
    }*/

    
}


