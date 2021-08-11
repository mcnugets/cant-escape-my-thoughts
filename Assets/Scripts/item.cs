using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]

public enum itemType
{
   Key,
   Hint 
}

[CreateAssetMenu(fileName = "New Item", menuName = "inventory/item")]



public  class item : ScriptableObject
{


    public itemType whichItem;
    public bool isUsed = false;
    public int ID;
    public string itemName;
    [TextArea(12,12)]
    public string descritpion;
    public Sprite  Image;
    public GameObject gameObjectPrefab;
    
    
}
