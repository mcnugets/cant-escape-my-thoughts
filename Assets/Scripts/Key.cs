using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public enum keyFor
{
    Door1,
    Door2,
    Door3
}
[CreateAssetMenu(fileName = "New Key", menuName = "inventory/Key")]


public class Key : item
{

   
    public keyFor keyFroThe;

}
