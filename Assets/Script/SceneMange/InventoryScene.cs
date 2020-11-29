using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScene : ObjectScene
{
    protected override void Start()
    {
        base.Start();
        usingDataset = "Item";
        inventoryMaker.Initialize("Item",this);
    }
}
