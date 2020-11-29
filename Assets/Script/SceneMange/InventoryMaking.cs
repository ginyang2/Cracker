using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMaking : MonoBehaviour
{
    public int size;
    public GameObject basePannel;
    public GameObject emptyPannel;
    // Start is called before the first frame update

    public void Initialize(string type, ObjectScene target)
    {
        InventoryData data = DataController.FindInvetory(type);
        Debug.Log(type);
        foreach (string i in data.itemIds)
        {
            CreateItemPannel(i,type, target);
        }
    }

    private void CreateItemPannel(string id,string dataset, ObjectScene target)
    {
        var itemPannel = Instantiate(emptyPannel, basePannel.transform);
        var image = itemPannel.GetComponent<Image>();
        Texture2D texture = Resources.Load(DataManager.Find(id,dataset,"Path").ToString()) as Texture2D;
        Rect rect = new Rect(0, 0, texture.width, texture.height);
        image.sprite = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));
        InventoryItemPannel itemPan = itemPannel.GetComponent<InventoryItemPannel>();
        itemPan.item.Id = id;
        itemPan.sceneManager = target;
    }
}
