using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

[CreateAssetMenu(fileName = "New Key", menuName = "inventory/Hint")]
public class Hint : item
{

   
   
    [TextArea(12, 12)]
    public string hintContent;


   
   
}
