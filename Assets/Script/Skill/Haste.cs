using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haste : Skill
{
    public float conTime = 10;//지속시간
    public GameObject hasteAffect;
    Animator animator;
    private bool destroy;
    public override IEnumerator UseSkill(Player player)
    {
        StartCoroutine(base.UseSkill(player));
        player.status.moveSpeed += 2;
        destroy = false;
        GameObject game = Instantiate(hasteAffect,GameObject.FindObjectOfType<Player>().transform);
        game.transform.localPosition = new Vector3(0f, 1f);
        StartCoroutine(WaitForAnimation(animator,game));
        yield return new WaitForSeconds(conTime);
        player.status.moveSpeed -= 2;
        destroy = true;
    }

    IEnumerator WaitForAnimation(Animator animator,GameObject game)
    {
        while (destroy == false)
        {
            yield return new WaitForEndOfFrame();
        }
        Destroy(game);
        yield break;
    }
}
