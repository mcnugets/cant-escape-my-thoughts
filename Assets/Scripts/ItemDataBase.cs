using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;



[CreateAssetMenu(fileName = "New Item Data Base", menuName = "inventory/Data Base/ItemID")]

[Serializable]
public class ItemDataBase : ScriptableObject, ISerializationCallbackReceiver
{
    //convert to binary

    public const int constIndex = 3 ;
    
    public Dictionary<item, int> retrireveID = new Dictionary<item, int>();
    public Dictionary<int, item> retrieveItem = new Dictionary<int, item>();  
    public List<InventorySlot> inventoryslot = new List<InventorySlot>();


    public void OnAfterDeserialize()
    {
      
        retrireveID = new Dictionary<item, int>();
        retrieveItem = new Dictionary<int, item>();

        for (int x = 0; x < inventoryslot.Count; x++)
        {
            if (inventoryslot[x] == null)
            {
                Debug.Log("SORRY DATA BASE IS EMPTY");
            }
            else
            {
                retrireveID.Add(inventoryslot[x].storedItem, x);
                retrieveItem.Add(x, inventoryslot[x].storedItem);
            }
        }
    }
    public void OnBeforeSerialize()
    {
        inventoryslot.Clear();
        foreach (var item in retrieveItem)
        {
            
            inventoryslot.Add(new InventorySlot(retrireveID[item.Value], item.Value));
        }

    }

    public void Save()
    {
        
        
        string datapath = Application.dataPath + "/inventoryData.json";   
        FileStream file = File.Open(datapath,FileMode.Create);
        string jsonString = JsonUtility.ToJson(this, true);
        byte[] tobyte = Encoding.UTF8.GetBytes(jsonString);
        foreach (var parse in tobyte)
        {
            file.WriteByte(parse);
        }
      
        
        file.Close();

    }


    public void Load() 
    {
        string datapath = Application.dataPath + "/inventoryData.json";
      
        FileStream fs = File.Open(datapath, FileMode.Open);
        byte[] getByte = new byte[fs.Length];
        fs.Read(getByte, 0, getByte.Length);
        JsonUtility.FromJsonOverwrite(Encoding.UTF8.GetString(getByte), this);
        fs.Close();
        
    }      

   
  

    // Start is called before the first frame update
  
}

