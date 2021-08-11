using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class useItemManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> theDoors;
    public GameObject HintNote;

    public void Start()
    {
      
    }
    public void KeyManager(Key key) 
    {
        if (key.keyFroThe == keyFor.Door1)
        {
            int d1 = (int)key.keyFroThe;
            door correctKey = theDoors[d1].GetComponent<door>();
            if (correctKey.inTrigger) 
            {
                correctKey.Unlock = true; 
                print("THE KEY HAS UNLOCKED THE DOOR");
            }

            //do the operation
        }

    }
    public void HintManager(Hint hint)
    {
        HintNote.SetActive(true);
        GameObject content = HintNote.transform.Find("Viewport").transform.Find("Content").gameObject;
        content.GetComponent<Text>().text = hint.hintContent;
        


    }
    public void Close()
    {
        HintNote.SetActive(false);
    }


}
