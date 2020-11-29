using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortAttack : Attack
{
    public Animator animator;
    private void Start()
    {
        StartCoroutine(WaitForAnimation(animator));
    }

    IEnumerator WaitForAnimation(Animator animator)
    {
        while (false == animator.IsInTransition(0))
        {
            yield return new WaitForEndOfFrame();
        }
        GameObject.Destroy(animator.gameObject);

    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        Debug.Log(collision.tag);
        if (collision.CompareTag("EnemyAttack"))
        {
            Destroy(collision.gameObject);
        }
    }
}
