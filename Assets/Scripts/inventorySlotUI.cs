using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
public class inventorySlotUI : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent RMB;
    public GameObject popUp;
    public inventory playerInventory;

    [SerializeField] public item getItem;
    // Start is called before the first frame update



    // Update is called once per frame
    void Awake()
    {
        if (playerInventory == null )
        {
            playerInventory = GameObject.FindWithTag("Player").GetComponent<inventory>();
        }
    }
    void Update() 
    {
        disablePopUp(popUp);
    }

    private void disablePopUp(GameObject popupMenu) 
    {
       
        if (Input.GetMouseButtonDown(0) && popupMenu.activeSelf && 
            !RectTransformUtility.RectangleContainsScreenPoint(popupMenu.GetComponent<RectTransform>(), Input.mousePosition) ||
            !RectTransformUtility.RectangleContainsScreenPoint(GetComponent<RectTransform>(), Input.mousePosition) && 
            Input.GetMouseButtonDown(1) && popupMenu.activeSelf)
        {

            Debug.Log(" IT IS WORKING MY GUY");
            popUp.SetActive(false);
        }
    }
 
    public void removeButton() 
    {

        playerInventory.RemoveItem(getItem); 

    }
    public void useItem() 
    {
        playerInventory.UseItem(getItem);
    }
    public void dropButton() 
    {
        playerInventory.DropItem(getItem);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            RMB.Invoke();
        }
    }
    public void activatePopUp()
    {
        popUp.SetActive(true);
        Debug.Log("SLLSJFLSDSJF");
    }
}
