using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//아이템을 사용하는 모든 씬의 부모(세팅, 인벤토리등) 추후에 더 직관성 있는 이름으로 변경하기
public class ObjectScene : MonoBehaviour
{
    protected InventoryMaking inventoryMaker;
    protected string usingDataset;
    public Image selectedItemImage;
    public Text selectedItemText;
    public GameObject selectedItem;
    public GameObject emptyPannel;

    virtual protected void Start()
    {
        DataController.Load();
        inventoryMaker = FindObjectOfType<InventoryMaking>();
    }

    virtual public void Affect(string id)
    {
        if(selectedItemText != null)
            selectedItemText.text = DataManager.Find(id, usingDataset, "Name").ToString();
        if (selectedItemImage != null)
        {
            Debug.Log("만들어짐");
            Texture2D texture = Resources.Load(DataManager.Find(id, usingDataset, "Path").ToString()) as Texture2D;
            Rect rect = new Rect(0, 0, texture.width, texture.height);
            selectedItemImage.sprite = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));
        }
    }
}
