using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    
    enum EnemyState
    {
        Idle,Move,Attack,Return,Damaged,Die
    }

    EnemyState state;

    #region "Idle 상태에 필요한변수들"

    Transform playerTr;

    #endregion
    #region "Move 상태에 필요한변수들"
    public float moveSpeed = 5.0f;
    #endregion
    #region "Attack 상태에 필요한변수들"
    public float attSpeed = 5.0f;
    #endregion
    #region "Return 상태에 필요한변수들"
    Transform enemyTr;
    #endregion
    #region "Damaged 상태에 필요한변수들"
    #endregion
    #region "Die 상태에 필요한변수들"
    #endregion

    private void Awake()
    {
        GameObject player = GameObject.Find("player");
        playerTr = player.GetComponent<Transform>();

        enemyTr = GetComponent<Transform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        state = EnemyState.Idle;
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Move:
                Move();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            case EnemyState.Return:
                Return ();
                break;
            case EnemyState.Damaged:
                Damaged();
                break;
            case EnemyState.Die:
                Die();
                break;
            
        }
    }

private void Idle()
    {
        
        if(Vector3.Distance(playerTr.position, transform.position) > 10.0f)
        {
            Debug.Log("적 대기");
        }
        else
        {
            Debug.Log("적 이동");
        }
    }

    private void Move()
    {
        
        if(Vector3.Distance (playerTr.position,transform.position) <= 10.0f)
        {
            Debug.Log("적 이동");
        }
        if(Vector3.Distance(playerTr.position,transform.position)>10.0f)
        {
            Debug.Log("적 대기");
        }
    }

    private void Attack()
    {
        
        if (Vector3.Distance(playerTr.position, transform.position) <= 1.0f)
        {
            Debug.Log("적 공격");
        }
        //공격범위안에 일정시간각격으로
        //공격범위를 벗어나면 이동
        //공격범위 1미터
        //상태변경
        //상태전환 출력
    }

    private void Return()
    {
        
        if(Vector3.Distance(enemyTr.position,transform.position) >= 30.0f)
        {
            Debug.Log("적 복귀");
        }
        //일정범위30미터
        //상태변경
        //상태전환 출력tranditional
    }

    private void Damaged()
    {
        
        //코루틴
        //몬스터 체력이 1 이상
        //다시 이전상태로 변경
        //상태변경
        //상태전환 출력
    }

    private void Die()
    {
        //코루틴
        //체력이 0이하
        //몬스터 오브젝트 삭제
        //상태변경
        //상태전환 출력(죽었다)
    }
}
