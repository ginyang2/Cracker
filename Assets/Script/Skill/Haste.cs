using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haste : Skill
{
    public float conTime = 10;//지속시간
    public override IEnumerator UseSkill(Player player)
    {
        StartCoroutine(base.UseSkill(player));
        player.status.moveSpeed += 2;
        yield return new WaitForSeconds(conTime);
        player.status.moveSpeed -= 2;
    }
}
