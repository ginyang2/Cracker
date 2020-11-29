using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//적1
public class Enemy2 : Enemy
{
    private GameObject target = null;
    private Player player = null;
    [SerializeField]
    private float attackRange;
    private bool isAttack;
    private bool targetting =false;
    private float distance;
    public GameObject setAttackPrefab;

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
    private void CheckAttack()
    {
        if (distance < attackRange && !isAttack)//공격가능이면
        {
            StartCoroutine(Attack(player,target.transform));
            Debug.Log("Attack!");
        }
    }

    IEnumerator Attack(Character player, Transform target)
    {
        if (!target)
        {
            Debug.Log("target is null");
        }
        isAttack = true;
        float angle = Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
        GameObject attackPrefab = Instantiate(setAttackPrefab, transform.position, Quaternion.identity);
        EnemyLongAttack longAttack = attackPrefab.GetComponent<EnemyLongAttack>();
        longAttack.targetPos = new Vector2(target.transform.position.x,target.transform.position.y);
        longAttack.damage = (int)status.attackPower;
        attackPrefab.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        yield return new WaitForSeconds(status.attackSpeed);
        isAttack = false;
    }

    private void OnDestroy()
    {
        GameManager.Instance.enemyNum -= 1;
    }
}
