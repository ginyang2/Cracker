using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryItemPannel : MonoBehaviour
{
    public Item item = new Item();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ClickAction()
    {
        ObjectScene sceneManager = GameObject.FindObjectOfType<ObjectScene>();
        sceneManager.Affect(item.Id);
    }
}
