using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class InventorySlot 
{
    // Start is called before the first frame update
    public int itemID;
    public item storedItem;
 
   public  InventorySlot(int itemID, item storedItem) 
    {
        this.itemID = itemID;
        this.storedItem = storedItem;
       
    }
}
