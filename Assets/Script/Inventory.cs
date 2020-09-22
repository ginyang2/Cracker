using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<int> ItemIdList;
    public int size;
    public GameObject emptyPannel;
    public GameObject basePannel;
    // Start is called before the first frame update
    void Start()
    {
        size = ItemIdList.Count;
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Initialize()
    {
        foreach(int i in ItemIdList)
        {
            CreateItemPannel(i);
        }
    }

    void CreateItemPannel(int id)
    {
        var itemPannel = Instantiate(emptyPannel, basePannel.transform);
        var image = itemPannel.GetComponent<Image>();
        Texture2D texture = Resources.Load(ItemDataManager.FindPath(id).ToString()) as Texture2D;
        Rect rect = new Rect(0, 0, texture.width, texture.height);
        image.sprite = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));
    }

    
}
