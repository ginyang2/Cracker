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

    virtual protected void Start()
    {
        DataController.Load();
        inventoryMaker = FindObjectOfType<InventoryMaking>();
    }

    public void Affect(string id)
    {
        selectedItemText.text = GameData.FindData(id, "ItemData", "name").ToString();
        Texture2D texture = Resources.Load(DataManager.FindPath(id, usingDataset).ToString()) as Texture2D;
        Rect rect = new Rect(0, 0, texture.width, texture.height);
        selectedItemImage.sprite = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));
    }
}
