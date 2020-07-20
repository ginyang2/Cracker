using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//적1
public class Enemy1 : Enemy
{
    private GameObject target = null;
    private Player player = null;
    [SerializeField]
    private float attackRange;
    public float attackPower;
    private bool isAttack;
    private bool targetting =false;
    private float distance;

    protected override void Start()
    {
        base.Start();
        player = FindObjectOfType<Player>();
    }
    protected override void Update()
    {
        base.Update();
        if (targetting)
        {
            Move();
            CheckAttack();
        }
    }

    private void Move()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);

        if (distance >= 0.01f) // 차이가 아직 있다면
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, status.moveSpeed * Time.deltaTime);
        }
        else
        {
            targetting = false;
        }
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            targetting = true;
            target = collision.gameObject;
        }
    }
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        targetPos = collision.transform.position;
    //        targetting = true;
    //        if(Vector2.Distance(transform.position,targetPos) < attackRange && !isAttack)
    //        {
    //            Character a = collision.GetComponent<Character>();
    //            Debug.Log(a.hp.MyCurrentValue);
    //            StartCoroutine(Attack(a));
    //        }
    //    }
    //}
    private void CheckAttack()
    {
        if (distance < attackRange && !isAttack)//공격가능이면
        {
            StartCoroutine(Attack(player));
            Debug.Log("Attack!");
        }
    }

    IEnumerator Attack(Character player)
    {
        isAttack = true;
        Debug.Log("Attacking" + distance);
        player.MHP((int)status.attackPower);
        yield return new WaitForSeconds(status.attackSpeed);
        isAttack = false;
    }

    private void OnDestroy()
    {
        GameManager.Instance.enemyNum -= 1;
    }
}
