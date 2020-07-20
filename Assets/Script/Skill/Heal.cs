using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Skill
{
    public float healPower;
    public override IEnumerator UseSkill(Player player)
    {
        StartCoroutine(base.UseSkill(player));
        player.MHP((int)(-1*(healPower)));
        yield return new WaitForEndOfFrame();
    }
}
