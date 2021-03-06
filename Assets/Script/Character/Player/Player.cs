﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//플레이어
public class Player : Character
{
    //이동관련
    public Vector2 targetPos;
    private Camera mainCamera;
    //벽 접촉여부 확인
    public bool isTouchRight;
    public bool isTouchLeft;
    public bool isTouchUp;
    public bool isTouchDown;
    //능력치관련
    public float strangth;
    public float intelligence;
    //애니메이션
    public Animator animator;
    //공격관련
    public GameObject attackPrefab;
    public Transform attackTarget;
    public bool isAttack;
    public GameObject attackRangeCirecle;
    //UI관련
    public Stat mp;
    //스킬관련
    [SerializeField]
    protected override void Start()
    {
        Debug.Log("Start");
        base.Start();
        status.weapon = GameManager.Instance.weapons[GameManager.Instance.weaponIdx];
        attackRangeCirecle.SetActive(false);
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        switch (status.weapon.WeaponType)
        {
            case 0:
            case 1:
            case 3:
                status.attackPower = status.weapon.Power + strangth;
                break;
            case 2:
                status.attackPower = status.weapon.Power + intelligence;
                break;
        }
        //HP,MPUI 초기화
        mp.Initialize(status.manaPoint, status.manaPoint);
    }
    void Update()
    {
        if (hp.MyCurrentValue <= 0)
        {
            GameManager.Instance.gameOver = true;
            animator.SetTrigger("Dead");
        }
        else
        {
            InputKey();
            Move(); 
        }
    }

    void InputKey()
    {
        //이동
        if (Input.GetMouseButtonDown(1))
        {
            targetPos = Input.mousePosition;
            targetPos = mainCamera.ScreenToWorldPoint(targetPos);
        }
        //공격
        if (Input.GetKey(KeyCode.A))
        {
            AttackReady();
            if (Input.GetMouseButtonDown(0) && !isAttack) {
                if (status.weapon.AttackType == 0)
                    StartCoroutine(Attack(mainCamera.ScreenToWorldPoint(Input.mousePosition)));
                else
                {
                    if (Vector2.Distance(transform.position, mainCamera.ScreenToWorldPoint(Input.mousePosition)) < status.weapon.range)
                    {   //공격 범위 안이라면
                        StartCoroutine(Attack(mainCamera.ScreenToWorldPoint(Input.mousePosition)));
                    }
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.A))
            attackRangeCirecle.SetActive(false);
        //스킬 사용
        if (Input.GetKeyDown(KeyCode.Q) && GameManager.Instance.skills[0].Check(this))
            StartCoroutine(GameManager.Instance.skills[0].UseSkill(this));
        if (Input.GetKeyDown(KeyCode.W) && GameManager.Instance.skills[1].Check(this))
            StartCoroutine(GameManager.Instance.skills[1].UseSkill(this));
        if (Input.GetKeyDown(KeyCode.E) && GameManager.Instance.skills[2].Check(this))
            StartCoroutine(GameManager.Instance.skills[2].UseSkill(this));
        if (Input.GetKeyDown(KeyCode.R) && GameManager.Instance.skills[3].Check(this))
            StartCoroutine(GameManager.Instance.skills[3].UseSkill(this));
    }

    void Move()
    {
        float dis = Vector2.Distance(transform.position, targetPos);
        //벽과의 충돌 판정
        Vector2 currentTPos = targetPos;
        if (isTouchLeft && targetPos.x < transform.position.x)
            currentTPos.x = transform.position.x;
        if (isTouchRight && targetPos.x > transform.position.x)
            currentTPos.x = transform.position.x;
        if (isTouchDown && targetPos.y < transform.position.y)
            currentTPos.y = transform.position.y;
        if (isTouchUp && targetPos.y > transform.position.y)
            currentTPos.y = transform.position.y;

        if (dis >= 0.01f) // 차이가 아직 있다면
        {
            transform.localPosition = Vector2.MoveTowards(transform.position, currentTPos, status.moveSpeed * Time.deltaTime);
        }
    }

    void AttackReady()
    {
        attackRangeCirecle.SetActive(true);
        attackRangeCirecle.transform.localScale = new Vector3(status.weapon.range, status.weapon.range);
    }

    IEnumerator Attack(Vector2 targetPos)
    {
        isAttack = true;
        float angle = Mathf.Atan2(targetPos.y - transform.position.y, targetPos.x - transform.position.x) * Mathf.Rad2Deg;
        GameObject attackPrefab = Instantiate(status.weapon.attackPrefab, transform.position, Quaternion.identity);
        if (status.weapon.AttackType == 0)
        {
            angle -= 45;
            attackPrefab.transform.localScale = new Vector3(status.weapon.range, status.weapon.range);
        }
        else if(status.weapon.AttackType == 1)
        {
            LongAttack longAttack = attackPrefab.GetComponent<LongAttack>();
            longAttack.targetPos = targetPos;
        }
        attackPrefab.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        yield return new WaitForSeconds(status.attackSpeed);
        isAttack = false;
    }
    public void MMP(float spend)
    {
        mp.MyCurrentValue -= spend;
    }
}
