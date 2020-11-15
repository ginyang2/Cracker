using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//아이템을 사용하는 모든 씬의 부모(세팅, 인벤토리등)
public class ObjectScene : MonoBehaviour
{
    protected InventoryMaking inventoryMaker;
    protected string usingDataset;
    public Image selectedItemImage;
    public Text selectedItemText;
    public GameObject selectedItem;

    virtual protected void Start()
    {
        DataController.Load();
        inventoryMaker = FindObjectOfType<InventoryMaking>();
    }

    virtual public void Affect(string id)
    {
        if(selectedItemText != null)
            selectedItemText.text = DataManager.Find(id, "ItemData", "name").ToString();
        if (selectedItemImage != null)
        {
            Debug.Log("만들어짐");
            Texture2D texture = Resources.Load(DataManager.Find(id, usingDataset, "path").ToString()) as Texture2D;
            Rect rect = new Rect(0, 0, texture.width, texture.height);
            selectedItemImage.sprite = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));
        }
    }
}
