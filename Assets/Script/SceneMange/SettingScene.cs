using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingScene : ObjectScene
{
    protected override void Start()
    {
        base.Start();
        usingDataset = "Skill";
        inventoryMaker.Initialize("Skill");
    }
}
