using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpUI : MonoBehaviour
{
    //  public inventory Inventory;
    public inventorySlotUI uiSlot;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UseItem() 
    {
        uiSlot.useItem();
    }
    public void Removeitem() 
    {
        uiSlot.removeButton();
    }
    public void DropItem() 
    {
        uiSlot.dropButton();
    }
}
